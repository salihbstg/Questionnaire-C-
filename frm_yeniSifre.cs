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

namespace AnketSistemi
{
    public partial class frm_yeniSifre : Form
    {
        public frm_yeniSifre()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
        public void araclariTemizle()
        {
            txtKadi.Text = "";
            txtSifre.Text = "";
            txtSifreTekrar.Text = "";
            txtTc.Clear();
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        baglanti sql = new baglanti();
        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand kmt = new SqlCommand("select tc from tbl_kullanicilar where tc=@p1 and kullaniciAdi=@p2", sql.sqlbaglan());
            kmt.Parameters.AddWithValue("@p1", txtTc.Text);
            kmt.Parameters.AddWithValue("@p2", txtKadi.Text);
            SqlDataReader dr = kmt.ExecuteReader();
            if (dr.Read())
            {
                SqlCommand kmt2=new SqlCommand("update tbl_kullanicilar set sifre=@p1 where kullaniciAdi=@p2 and tc=@p3",sql.sqlbaglan());
                kmt2.Parameters.AddWithValue("@p1", txtSifre.Text);
                kmt2.Parameters.AddWithValue("@p2", txtKadi.Text);
                kmt2.Parameters.AddWithValue("@p3", txtTc.Text);
                kmt2.ExecuteNonQuery();
                MessageBox.Show("Şifreniz değiştirildi.");                
                sql.sqlbaglan().Close();
                araclariTemizle();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Lütfen doğru tc numarası giriniz");

            }
        }
    }
}
