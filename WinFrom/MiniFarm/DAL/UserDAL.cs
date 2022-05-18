using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class UserDAL:DataDAL
    {
        public List<User> LayToanBoSanPham()
        {
            List<User> LsUser = new List<User>();
            openconn();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "select *from Login";
            command.Connection = conn;
            SqlDataReader reader = command.ExecuteReader();
            while(reader.Read())
            {
                User us = new User();
                us.UserName = reader.GetString(0);
                us.PassWord = reader.GetString(1);
                LsUser.Add(us);
            }
            reader.Close();
            return LsUser;
        }
        public User TimUser(string UserName)
        {
            User us = null;
            openconn();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "select *from Login where UserName = @user";
            SqlParameter parUser = new SqlParameter("@user", SqlDbType.NVarChar);
            parUser.Value = UserName;
            command.Parameters.Add(parUser);
            command.Connection = conn;
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                us = new User();
                us.UserName = reader.GetString(0).Trim();
                us.PassWord = reader.GetString(1).Trim();
            }
            reader.Close();
            return us;
        }
    }
}
