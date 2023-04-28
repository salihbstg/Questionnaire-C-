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
    public partial class frm_anketolustur : Form
    {
        public frm_anketolustur()
        {
            InitializeComponent();
        }
        baglanti sql = new baglanti();
        public string tcno;
        private void frm_anketolustur_Load(object sender, EventArgs e)
        {
            
            button1.BackColor = Color.FromArgb(120, 50, 50, 90);
            panel1.BackColor = Color.FromArgb(90, 75, 75, 150);
            label1.BackColor = Color.Transparent;
            label2.BackColor = Color.Transparent;
            label3.BackColor=Color.Transparent;
            label4.BackColor = Color.Transparent;
            label5.BackColor = Color.Transparent;
            label6.BackColor = Color.Transparent;
            label1.Font = new Font("area",8,FontStyle.Bold);
            label2.Font = new Font("area", 8, FontStyle.Bold);
            label3.Font = new Font("area", 8, FontStyle.Bold);
            label4.Font = new Font("area", 8, FontStyle.Bold);
            label5.Font = new Font("area", 8, FontStyle.Bold);
            label6.Font = new Font("area", 8, FontStyle.Bold);
            label7.Text = tcno;
           
            
            

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        frm_giris giris = new frm_giris();
      
        public void araclariTemizle()
        {
            txt1.Text = "";
            txt2.Text = "";
            txt3.Text = "";
            txt4.Text = "";
            txt5.Text = "";
            baslik.Text = "";
        }
        private void button1_Click(object sender, EventArgs e)
        {

            
            SqlCommand kmt = new SqlCommand("insert into tbl_anketler " +
                "(baslik,secenek1,secenek2,secenek3,secenek4,secenek5,olusturantc,oylar1,oylar2,oylar3,oylar4,oylar5) " +
                "values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11,@p12)", sql.sqlbaglan());
            kmt.Parameters.AddWithValue("@p1", baslik.Text);
            kmt.Parameters.AddWithValue("@p7", tcno);
            kmt.Parameters.AddWithValue("@p2", txt1.Text);
            kmt.Parameters.AddWithValue("@p3", txt2.Text);
            kmt.Parameters.AddWithValue("@p8", 0f);
            kmt.Parameters.AddWithValue("@p9", 0f);
            if (txt3.Text != "")
            {
                kmt.Parameters.AddWithValue("@p4", txt3.Text);
                kmt.Parameters.AddWithValue("@p10",0);
            }
            else
            {
                kmt.Parameters.AddWithValue("@p4", DBNull.Value);
                kmt.Parameters.AddWithValue("@p10", DBNull.Value);
            }
            if (txt4.Text != "")
            {
                kmt.Parameters.AddWithValue("@p5", txt4.Text);
                kmt.Parameters.AddWithValue("@p11",0);
            }
            else
            {
                kmt.Parameters.AddWithValue("@p5", DBNull.Value);
                kmt.Parameters.AddWithValue("@p11", DBNull.Value);
            }
            if (txt5.Text != "")
            {
                kmt.Parameters.AddWithValue("@p6", txt5.Text);
                kmt.Parameters.AddWithValue("@p12",0);
            }
            else
            {
                kmt.Parameters.AddWithValue("@p6", DBNull.Value);
                kmt.Parameters.AddWithValue("@p12", DBNull.Value);
            }
            kmt.ExecuteNonQuery();
            MessageBox.Show("Anket başarıyla oluşturuldu");
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            pictureBox1.BackColor = Color.Gray;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.BackColor = Color.Transparent;
        }
    }
}
