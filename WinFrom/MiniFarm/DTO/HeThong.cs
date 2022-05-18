using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    /// <summary>
    /// Lưu thông số cài đặt của hệ thống.
    /// </summary>
    public class HeThong
    {
        private List<int> AirTem = new List<int>();
        private List<int> AirHumi = new List<int>();
        private List<int> SoilHumi = new List<int>();
        public void AddAirTem(List<int> LsAirTem)
        {
            this.AirTem.Clear();
            this.AirTem = LsAirTem;
        }
        public void AddAirHumi(List<int> LsAirhumi)
        {
            this.AirHumi.Clear();
            this.AirHumi = LsAirhumi;
        }
        public void AddSoilHumi(List<int> LsSoilHumi)
        {
            this.SoilHumi.Clear();
            this.SoilHumi = LsSoilHumi;
        }
        public int Arvage_AirHumi()
        {
            int sum = 0;
            foreach(int value in AirHumi)
            {
                sum += value;
            }
            return sum / AirHumi.Count;
        }
        public int Arvage_AirTem()
        {
            int sum = 0;
            foreach(int value in AirTem)
            {
                sum += value;
            }
            return sum / AirTem.Count;
        }
        public int Arvage_SoilHumi()
        {
            int sum = 0;
            foreach(int value in SoilHumi)
            {
                sum += value;
            }
            return sum / SoilHumi.Count;
        }
        public bool HeThongDangHoatDongBinhThuong()
        {
            if (Arvage_AirHumi() > 25 && Arvage_AirTem() > 25 && Arvage_SoilHumi() > 25) return true;
            return false;
        }
        //Cả hệ thống ơ trạng thái bật hay tắt
        public bool BatTatHeThong { get; set; }

        // Hệ thống đang ở trại thái nào: -1 OFF, 0 auto, 1 manual.
        public int CheDoHeThong { get; set; }

        // trả về 0 nếu không có vấn đề gì. 
        //trả về -1 nếu phát sinh lỗi, trả về 1 khi đang thực hiện khởi động hệ thống
        //trả về 2 nếu hê thống đang oFF
        public int TinhTrangToanHeThong { get; set; }
        
    }
}
