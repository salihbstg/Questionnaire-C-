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
    public partial class frm_kullanicilar : Form
    {
        public frm_kullanicilar()
        {
            InitializeComponent();
        }
        baglanti sql = new baglanti();
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            pictureBox1.BackColor = Color.White;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.BackColor = Color.Transparent;
        }
        private void frm_kullanicilar_Load(object sender, EventArgs e)
        {
            

            this.BackColor= Color.FromArgb(50, 50, 90);
            SqlDataAdapter da = new SqlDataAdapter("select ad,Soyad from tbl_kullanicilar", sql.sqlbaglan());
            DataTable dt = new DataTable();
            da.Fill(dt);
            
            dataGridView1.DataSource = dt;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dataGridView1.Columns[0].Width = 150;
            dataGridView1.Columns[1].Width = 150;
            dataGridView1.Columns[0].HeaderText = "Ad";
            dataGridView1.Columns[1].HeaderText = "Soyad";
            for(int i=0;i<dataGridView1.Rows.Count;i++)
            {
                if (i % 2 == 0)
                {
                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Gray;
                    
                }
                dataGridView1.Rows[i].Height = 40;

            }
            sayi.Text = dataGridView1.Rows.Count.ToString();
            
        }
    }
}
