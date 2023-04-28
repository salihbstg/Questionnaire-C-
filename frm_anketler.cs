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
using System.Data.Common;

namespace AnketSistemi
{
    public partial class frm_anketler : Form
    {
        public frm_anketler()
        {
            InitializeComponent();
        }
        baglanti sql = new baglanti();
        private void frm_anketler_Load(object sender, EventArgs e)
        {
            dataGridView1.Font = new Font("Arial", 12);
            tcno.Text = tc;
            id.BackColor = Color.Transparent;
            button1.BackColor = Color.FromArgb(90, 50, 50, 90);
            button2.BackColor = Color.FromArgb(90, 50, 50, 90);
            panel2.BackColor = Color.FromArgb(50, 50, 50, 90);
            label1.BackColor = Color.Transparent;
            label2.BackColor = Color.Transparent;
            label3.BackColor = Color.Transparent;
            label4.BackColor = Color.Transparent;
            label5.BackColor = Color.Transparent;
            label7.BackColor = Color.Transparent;
            label8.BackColor = Color.Transparent;
            label9.BackColor = Color.Transparent;
            label10.BackColor = Color.Transparent;
            label11.BackColor = Color.Transparent;
            panel1.BackColor = Color.FromArgb(50, 50, 50, 90);
            s1.BackColor = Color.Transparent;
            s3.BackColor = Color.Transparent;
            s2.BackColor = Color.Transparent;
            s4.BackColor = Color.Transparent;
            s5.BackColor = Color.Transparent;

            gridDoldur();
            gridAyarla();
        }
        public string tc;
        public void gridDoldur()
        {
            //Kodlar
            SqlDataAdapter da = new SqlDataAdapter("select * from tbl_anketler", sql.sqlbaglan());
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            frm_grafikler a = new frm_grafikler();
            a.idcek = Convert.ToInt32(id.Text);
            a.ShowDialog();
        }
        public void gridAyarla()
        {
            dataGridView1.Columns[0].Width = 30;
            dataGridView1.Columns[1].Width = 330;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (i % 2 == 0)
                {
                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Gray;
                    dataGridView1.Rows[i].DefaultCellStyle.ForeColor = Color.White;

                }
                dataGridView1.Rows[i].Height = 40;
                

            }
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[1].HeaderText = "Anket Başlığı";
            dataGridView1.Columns[2].HeaderText = "1.Seçenek";
            dataGridView1.Columns[3].HeaderText = "2.Seçenek";
            dataGridView1.Columns[4].HeaderText = "3.Seçenek";
            dataGridView1.Columns[5].HeaderText = "4.Seçenek";
            dataGridView1.Columns[6].HeaderText = "5.Seçenek";
            dataGridView1.Columns[7].HeaderText = "1.Oylar";
            dataGridView1.Columns[8].HeaderText = "2.Oylar";
            dataGridView1.Columns[9].HeaderText = "3.Oylar";
            dataGridView1.Columns[10].HeaderText = "4.Oylar";
            dataGridView1.Columns[11].HeaderText = "5s.Oylar";
            dataGridView1.Columns[12].HeaderText = "Oluşturanın tcsi";
          
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
            button1.Visible = true;
            if (s1.Text == "")
            {
                s1.Visible = false;
            }
            else
                s1.Visible = true;
            if (s2.Text == "")
            {
                s2.Visible = false;
            }
            else
                s2.Visible = true;
            if (s3.Text == "")
            {
                s3.Visible = false;
            }
            else
                s3.Visible = true;
            if (s4.Text == "")
            {
                s4.Visible = false;
            }
            else
                s4.Visible = true;
            if (s5.Text == "")
            {
                s5.Visible = false;
            }
            else
                s5.Visible = true;
            gridAyarla();
            label1.Text = dataGridView1.Rows[a].Cells[2].Value.ToString();
            label2.Text = dataGridView1.Rows[a].Cells[3].Value.ToString();
            label3.Text = dataGridView1.Rows[a].Cells[4].Value.ToString();
            label4.Text = dataGridView1.Rows[a].Cells[5].Value.ToString();
            label5.Text = dataGridView1.Rows[a].Cells[6].Value.ToString();
            label11.Text = dataGridView1.Rows[a].Cells[7].Value.ToString();
            label10.Text = dataGridView1.Rows[a].Cells[8].Value.ToString();
            label9.Text = dataGridView1.Rows[a].Cells[9].Value.ToString();
            label8.Text = dataGridView1.Rows[a].Cells[10].Value.ToString();
            label7.Text = dataGridView1.Rows[a].Cells[11].Value.ToString();
            

        }
        public void oyVerildi()
        {
            MessageBox.Show("Oyunuz başarıyla alındı.");
            SqlCommand kmt3 = new SqlCommand("insert into tbl_oylananlar (id,tc) values (@p1,@p2)", sql.sqlbaglan());
            kmt3.Parameters.AddWithValue("@p1", id.Text);
            kmt3.Parameters.AddWithValue("@p2", tcno.Text);
            kmt3.ExecuteNonQuery();
            sql.sqlbaglan().Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            

            SqlCommand kmt2 = new SqlCommand("select * from tbl_oylananlar where id=@p1 and tc=@p2", sql.sqlbaglan());
            kmt2.Parameters.AddWithValue("@p1", id.Text);
            kmt2.Parameters.AddWithValue("@p2", tcno.Text);
            SqlDataReader dr2 = kmt2.ExecuteReader();
            if (dr2.Read())
            {
                MessageBox.Show("Aynı anketi yalnızca 1 kez oylayabilirsiniz", "Zaten daha önce oy kullandınız", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else {    
                if (s1.Checked == true){
                SqlCommand kmt = new SqlCommand("update tbl_anketler set oylar1=oylar1+1 where id="+id.Text,sql.sqlbaglan());
                kmt.ExecuteNonQuery();
                sql.sqlbaglan().Close();
                    oyVerildi();
                    gridDoldur();
                    gridAyarla();
                }
                else if (s2.Checked == true){
                    SqlCommand kmt = new SqlCommand("update tbl_anketler set oylar2=oylar2+1 where id=" + id.Text, sql.sqlbaglan());
                    kmt.ExecuteNonQuery();
                    sql.sqlbaglan().Close();
                    oyVerildi();
                    gridDoldur();
                    gridAyarla();
                }
                else if (s3.Checked == true){ 
                    SqlCommand kmt = new SqlCommand("update tbl_anketler set oylar3=oylar3+1 where id=" + id.Text, sql.sqlbaglan());
                    kmt.ExecuteNonQuery();
                    sql.sqlbaglan().Close();
                    oyVerildi();
                    gridAyarla();
                    gridDoldur();
                }
                else if (s4.Checked == true){
                    SqlCommand kmt = new SqlCommand("update tbl_anketler set oylar4=oylar4+1 where id=" + id.Text, sql.sqlbaglan());
                    kmt.ExecuteNonQuery();
                    sql.sqlbaglan().Close();
                    oyVerildi();
                    gridAyarla();
                    gridDoldur();
                }
                else if (s5.Checked == true){
                    SqlCommand kmt = new SqlCommand("update tbl_anketler set oylar5=oylar5+1 where id=" + id.Text, sql.sqlbaglan());
                    kmt.ExecuteNonQuery();
                    sql.sqlbaglan().Close();
                    oyVerildi();
                    gridDoldur();
                    gridAyarla();
                }
                else
                {
                    MessageBox.Show("Lütfen bir şıkkı seçin.");
                }

                label1.Text = "";
                label2.Text = "";
                label3.Text = "";
                label4.Text = "";
                label5.Text = "";
                label7.Text = "";
                label8.Text = "";
                label9.Text = "";
                label10.Text = "";
                label11.Text = "";

            }
            
            
        }
    }
}
