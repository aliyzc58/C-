using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        Sqlbaglantisi bgl = new Sqlbaglantisi();




        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            textBox1.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = true;

            Liatele();
        }
        void Liatele()
        {
            SqlCommand komut = new SqlCommand("select * from veriler", bgl.baglanti());
            SqlDataAdapter da = new SqlDataAdapter(komut);

            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        void ekle()
        {

            SqlCommand komut = new SqlCommand("insert into veriler (id,ad,soyad) values (@p1,@p2,@p3)", bgl.baglanti());

            komut.Parameters.AddWithValue("@p1", textBox1.Text);
            komut.Parameters.AddWithValue("@p2", textBox2.Text);
            komut.Parameters.AddWithValue("@p3", textBox3.Text);
            komut.ExecuteNonQuery();
            MessageBox.Show("Kayıt tamamlandı");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ekle();
            Liatele();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("delete from veriler where id=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", textBox1.Text);

            komut.ExecuteNonQuery();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update veriler set soyad=@p3,ad=@p2 where id=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", textBox1.Text);
            komut.Parameters.AddWithValue("@p2", textBox2.Text);
            komut.Parameters.AddWithValue("@p3", textBox3.Text);
            komut.ExecuteNonQuery();
            MessageBox.Show("güncelleme yapıldı");
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            int sayi, sonuc = 1;
            sayi = Convert.ToInt32(textBox3.Text);
            for (int i = 1; i <= sayi; i++)
            {
                sonuc *= i;

            }
            textBox4.Text = sonuc.ToString();
        }

        private void secilen(object sender, EventArgs e)
        {
            if (textBox4.Text == "0")
            {
                
                    textBox4.Text = "";
                
               
            }
            textBox4.Text = textBox4.Text + ((Button)sender).Text;
        }
        double sayi1, sayi2;
        int secim = 0;
        double sonuc = 0;

        private void button6_Click(object sender, EventArgs e)
        {
            sayi2 = double.Parse(textBox4.Text);
            if (secim == 1)
            {
                sonuc = sayi1 + sayi2;
                textBox4.Text = sonuc.ToString();
               }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox4.Text = "0";
        }

        private void button12_Click(object sender, EventArgs e)
        {
            textBox4.Text = textBox4.Text.Substring(0, textBox4.Text.Length - 1);
            if (textBox4.Text == "")
            {
                textBox4.Text = "0";
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            sayi1=double.Parse(textBox4.Text);
            textBox4.Text = "0";
            secim = 1;
         
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace WindowsFormsApp2
{
    class Sqlbaglantisi
    {
        public SqlConnection baglanti()
        {
            SqlConnection baglan = new SqlConnection(@"Data Source=Z-20-04;Initial Catalog=kullanici;Integrated Security=True");
            baglan.Open();
            return baglan;

        }


    }
}
