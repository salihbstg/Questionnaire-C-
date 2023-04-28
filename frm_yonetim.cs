using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnketSistemi
{
    public partial class frm_yonetim : Form
    {
        public frm_yonetim()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            frm_giris a = new frm_giris();
            a.ShowDialog();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frm_kullanicilar a = new frm_kullanicilar();
            a.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            frm_anketler a = new frm_anketler();
            a.tc = tcno;
            a.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frm_anketolustur a = new frm_anketolustur(); 
            a.tcno = this.tcno;
            a.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Üzerine çift tıkladığının anketin bilgileri yazdırılır.", "Bilgilendirme", MessageBoxButtons.OK,MessageBoxIcon.Information); ;
            frm_anketyonet a = new frm_anketyonet();
            a.tcno = this.tcno;
            a.ShowDialog();
            
        }
        public string tcno;
        private void frm_yonetim_Load(object sender, EventArgs e)
        {
            label2.Text = tcno;
            label2.BackColor = Color.Transparent;
            label1.BackColor = Color.Transparent;
            button1.BackColor = Color.FromArgb(140, 50, 50, 90);
            button2.BackColor = Color.FromArgb(140, 50, 50, 90);
            button3.BackColor = Color.FromArgb(140, 50, 50, 90);
            button4.BackColor = Color.FromArgb(140, 50, 50, 90);
            
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.BackColor = Color.Transparent;
        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            pictureBox1.BackColor = Color.DarkGray;
        }
    }
}
