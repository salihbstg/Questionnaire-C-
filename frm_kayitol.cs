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
    public partial class frm_kayitol : Form
    {
        public frm_kayitol()
        {
            InitializeComponent();
        }
        baglanti sql = new baglanti();
        private void frm_kayitol_Load(object sender, EventArgs e)
        {
            label5.BackColor = Color.Transparent;
            label6.BackColor = Color.Transparent;
            label1.BackColor = Color.Transparent;
            label2.BackColor = Color.Transparent;
            label3.BackColor = Color.Transparent;
            label4.BackColor = Color.Transparent;
            panel1.BackColor = Color.FromArgb(90, 100, 110, 120);
        }

        private void btn_giris_Click(object sender, EventArgs e)
        {
            if(txtSifre.Text==txtSifreTekrar.Text) {
            SqlCommand kmt = new SqlCommand("insert into tbl_kullanicilar (sifre,kullaniciAdi,ad,Soyad,tc) values (@p1,@p2,@p3,@p4,@p5)", sql.sqlbaglan());
            kmt.Parameters.AddWithValue("@p1", txtSifre.Text);
            kmt.Parameters.AddWithValue("@p2", txtKadi.Text);
            kmt.Parameters.AddWithValue("@p3", txtAd.Text);
            kmt.Parameters.AddWithValue("@p4", txtSoyad.Text);
            kmt.Parameters.AddWithValue("@p5", txtTC.Text);
            kmt.ExecuteNonQuery();
            sql.sqlbaglan().Close();
            MessageBox.Show("Kayıt başarılı.");
            this.Hide();
            }
            else
            {
                MessageBox.Show("İki şifre birbirinden farklı yazılamaz");
            }
        }
    }
}
