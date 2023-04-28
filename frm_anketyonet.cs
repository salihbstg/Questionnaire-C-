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
    public partial class frm_anketyonet : Form
    {
        public frm_anketyonet()
        {
            InitializeComponent();
        }
        public string tcno;
        baglanti sql = new baglanti();
        public void gridDoldur()
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from tbl_anketler where olusturantc=" + tcno, sql.sqlbaglan());

            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void frm_anketyonet_Load(object sender, EventArgs e)
        {
            dataGridView1.Font = new Font("Arial", 12);
            label8.Text = tcno;
            gridDoldur();
            gridYenile();
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[1].HeaderText = "SORU";
            dataGridView1.Columns[2].HeaderText = "S1";
            dataGridView1.Columns[3].HeaderText = "S2";
            dataGridView1.Columns[4].HeaderText = "S3";
            dataGridView1.Columns[5].HeaderText = "S4";
            dataGridView1.Columns[6].HeaderText = "S5";
            dataGridView1.Columns[7].HeaderText = "OY 1";
            dataGridView1.Columns[8].HeaderText = "OY 2";
            dataGridView1.Columns[9].HeaderText = "OY 3";
            dataGridView1.Columns[10].HeaderText = "OY 4";
            dataGridView1.Columns[11].HeaderText = "OY 5";
            dataGridView1.Columns[12].HeaderText = "OLUŞTURAN";
            

        }
        public void araclariTemizle()
        {
            s1.Text = "";
            s2.Text = "";
            s3.Text = "";
            s4.Text = "";
            s5.Text = "";
            id.Text = "";
            sayi1.Text = "";
            sayi2.Text = "";
            sayi3.Text = "";
            sayi4.Text = "";
            sayi5.Text = "";
            label2.Text = "";
            
        }
        public void gridYenile()
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (i % 2 == 0)
                {
                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Gray;
                    dataGridView1.Rows[i].DefaultCellStyle.ForeColor = Color.White;

                }
                dataGridView1.Rows[i].Height = 40;


            }
           
        }
        private void button1_Click(object sender, EventArgs e)
        {
            

            
            MessageBox.Show("Anketiniz sonuçlanmıştır");
            gridDoldur();
            gridYenile();
            SqlCommand kmt = new SqlCommand("delete from tbl_anketler where id=@p1", sql.sqlbaglan());
            kmt.Parameters.AddWithValue("@p1", id.Text);
            kmt.ExecuteNonQuery();
            
            araclariTemizle();
            
           

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int a = dataGridView1.SelectedCells[0].RowIndex;
            id.Text = dataGridView1.Rows[a].Cells[0].Value.ToString();

            s1.Text = dataGridView1.Rows[a].Cells[2].Value.ToString();
            s2.Text = dataGridView1.Rows[a].Cells[3].Value.ToString();            
            s3.Text = dataGridView1.Rows[a].Cells[4].Value.ToString();
            s4.Text = dataGridView1.Rows[a].Cells[5].Value.ToString();
            s5.Text = dataGridView1.Rows[a].Cells[6].Value.ToString();
            label2.Text= dataGridView1.Rows[a].Cells[1].Value.ToString();

            sayi1.Text = dataGridView1.Rows[a].Cells[7].Value.ToString();
            sayi2.Text = dataGridView1.Rows[a].Cells[8].Value.ToString();
            sayi3.Text = dataGridView1.Rows[a].Cells[9].Value.ToString();
            sayi4.Text = dataGridView1.Rows[a].Cells[10].Value.ToString();
            sayi5.Text = dataGridView1.Rows[a].Cells[11].Value.ToString();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            frm_grafikler a = new frm_grafikler();
            a.idcek = Convert.ToInt32(id.Text);
            a.ShowDialog();
        }
    }
}

