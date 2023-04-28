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
    public partial class frm_grafikler : Form
    {
        public frm_grafikler()
        {
            InitializeComponent();
        }
        public int idcek;
        baglanti sql = new baglanti();
        private void frm_grafikler_Load(object sender, EventArgs e)
        {
            label1.Text = idcek.ToString();
            SqlCommand kmt = new SqlCommand("select secenek1,oylar1 from tbl_anketler where id=" + idcek, sql.sqlbaglan());
            SqlDataReader dr = kmt.ExecuteReader();
            if (dr.Read())
            {
                chart1.Series["Oy Toplamları"].Points.AddXY(dr[0].ToString(), dr[1].ToString());
            }
            SqlCommand kmt2 = new SqlCommand("select secenek2,oylar2 from tbl_anketler where id=" + idcek, sql.sqlbaglan());
            SqlDataReader dr2 = kmt2.ExecuteReader();
            if (dr2.Read())
            {
                chart1.Series["Oy Toplamları"].Points.AddXY(dr2[0].ToString(), dr2[1].ToString());
            }
            SqlCommand kmt3 = new SqlCommand("select secenek3,oylar3 from tbl_anketler where id=" + idcek, sql.sqlbaglan());
            SqlDataReader dr3 = kmt3.ExecuteReader();
            if (dr3.Read())
            {
                chart1.Series["Oy Toplamları"].Points.AddXY(dr3[0].ToString(), dr3[1].ToString());
            }
            SqlCommand kmt4 = new SqlCommand("select secenek4,oylar4 from tbl_anketler where id=" + idcek, sql.sqlbaglan());
            SqlDataReader dr4 = kmt4.ExecuteReader();
            if (dr4.Read())
            {
                chart1.Series["Oy Toplamları"].Points.AddXY(dr4[0].ToString(), dr4[1].ToString());
            }
            SqlCommand kmt5 = new SqlCommand("select secenek5,oylar5 from tbl_anketler where id=" + idcek, sql.sqlbaglan());
            SqlDataReader dr5 = kmt5.ExecuteReader();
            if (dr5.Read())
            {
                chart1.Series["Oy Toplamları"].Points.AddXY(dr5[0].ToString(), dr5[1].ToString());
            }

        }
    }
}
