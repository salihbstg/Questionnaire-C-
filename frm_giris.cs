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
    public partial class frm_giris : Form
    {
        public frm_giris()
        {
            InitializeComponent();
            
        }
        baglanti sql = new baglanti();
        private void button1_MouseHover(object sender, EventArgs e)
        {
            
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        public void araclariTemizle()
        {
            txtSifre.Text = "";
            txtKadi.Text = "";
        }
        private void Form1_Load(object sender, EventArgs e)
        {

            pictureBox4.BackColor = Color.Transparent;
            pictureBox1.BackColor = Color.Transparent;
            linkSifre.BackColor = Color.Transparent;
            linkKayit.BackColor = Color.Transparent;
            label2.BackColor = Color.Transparent;
            label3.BackColor = Color.Transparent;
            
            panel1.BackColor = Color.FromArgb(118, 100, 110, 120);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            pictureBox1.BackColor = Color.FromArgb(90, 100, 110, 120);
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.BackColor = Color.Transparent;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        
        //Giriş yap
        private void btn_giris_Click(object sender, EventArgs e)
        {
            SqlCommand kmt = new SqlCommand("select tc from tbl_kullanicilar where kullaniciAdi=@p1 and sifre=@p2", sql.sqlbaglan());
            kmt.Parameters.AddWithValue("@p1", txtKadi.Text);
            kmt.Parameters.AddWithValue("@p2", txtSifre.Text);
            SqlDataReader dr = kmt.ExecuteReader();
            
            if (dr.Read())
            {


                
                this.Hide();
                frm_yonetim a = new frm_yonetim();
                a.tcno = dr[0].ToString();

                a.ShowDialog();
                
                          
            }
            else
            {
                MessageBox.Show("Yanlış kullanıcı adı veya şifre girdiniz","Üye bulunamadı!",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                araclariTemizle();
                
            }
            sql.sqlbaglan().Close();

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frm_kayitol a = new frm_kayitol();
            a.ShowDialog();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frm_yeniSifre a=new frm_yeniSifre();
            a.ShowDialog();
        }
    }
}
