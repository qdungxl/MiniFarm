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
    public class SensorDAL:DataDAL
    {
       public void GhiDuLieuSensor(Sensor ss)
        {
            openconn();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "insert into Sensor(Date,AirTem,AirHumi,SoilHumi) values (@date,@airtem,@airhumi,@soilhumi)";
            command.Connection = conn;
            command.Parameters.Add("@date", SqlDbType.DateTime).Value = DateTime.Now;
            command.Parameters.Add("@airtem", SqlDbType.Int).Value = ss.AirTem;
            command.Parameters.Add("@airhumi", SqlDbType.Int).Value = ss.AirHumi;
            command.Parameters.Add("@soilhumi", SqlDbType.Int).Value = ss.SoilHumi;
            int ret = command.ExecuteNonQuery();
        }
    }
}
