using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ArduinoMaster
    {
        public string[] ListBaudRate = { "1200", "2400", "4800", "9600", "19200", "38400", "57600", "115200" };
        public string BaundRate { get; set; }
        public string Com { get; set; }
        public bool ConnState { get; set; }
        public string Recive { get; set; }
        public string Send { get; set; }
         public ArduinoMaster()
        {
            BaundRate = ListBaudRate[3];
            ConnState = false;
        }       
    }
}
