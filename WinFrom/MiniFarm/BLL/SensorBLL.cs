using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BLL
{
    public class SensorBLL
    {
        public void GhiDuLieuSensor(Sensor ss)
        {
            new SensorDAL().GhiDuLieuSensor(ss);
        }
    }
}
