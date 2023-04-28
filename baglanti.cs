using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnketSistemi
{
    internal class baglanti
    {
        public SqlConnection sqlbaglan()
        {
            SqlConnection baglan = new SqlConnection("Data Source=DESKTOP-Q9SVK0G\\SQLEXPRESS;Initial Catalog=anketDatabase;Integrated Security=True");
            baglan.Open();
            return baglan;
        }
    }
}
