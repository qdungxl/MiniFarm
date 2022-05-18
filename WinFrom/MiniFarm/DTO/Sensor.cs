using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Sensor
    {
        public DateTime Date { get; set; }
        public int AirTem { get; set; }
        public int AirHumi { get; set; }
        public int SoilHumi { get; set; }
    }
}
