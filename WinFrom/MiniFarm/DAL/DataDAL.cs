using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class DataDAL
    {
        string sqlconn = @"Data Source=DESKTOP-JO2L41E\SQLEXPRESS;Initial Catalog=MiniFarm;Integrated Security=True";
        protected SqlConnection conn = null;
        public void openconn()
        {
            if (conn == null)
                conn = new SqlConnection(sqlconn);
            if (conn.State == ConnectionState.Closed)
                conn.Open();
        }
        public void closeconn()
        {
            if (conn != null && conn.State == ConnectionState.Open)
                conn.Close();
        }
    }
}
