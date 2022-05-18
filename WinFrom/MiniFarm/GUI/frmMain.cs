using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using BLL;
using System.IO;
using System.IO.Ports;

namespace GUI
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private HeThong MiniFarm = null;
        string Mess = "";

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void splitContainer2_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
          
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            
        }

        private void KhoiDongHeThong()
        {
            MiniFarm = new HeThong();
            MiniFarm.BatTatHeThong = false;
            MiniFarm.CheDoHeThong = -1; //OFF
            MiniFarm.TinhTrangToanHeThong = 2; 
            HienThi();
            CheDoHoatDong();
        }

        private void CheDoHoatDong()
        {
            splitContainerManualAuto.Enabled = true;
            if (MiniFarm.CheDoHeThong == 0)
            {
                cheDoTuDong();
            }
            else if (MiniFarm.CheDoHeThong == 1)
            {
                CheDoManual();
            }
        }

        private void CheDoManual()
        {
            gbGiaoTiepMaster.Enabled = true;
            gbDieuKhien.Enabled = true;
            ArduinoMaster ArMaster = new ArduinoMaster();
            cobBoundRate.Items.AddRange(ArMaster.ListBaudRate);
            cobBoundRate.SelectedIndex = 4;
            cobCOM.Items.AddRange(SerialPort.GetPortNames());
        }

        private void cheDoTuDong()
        {
            gbGiaoTiepMaster.Enabled = false;
            gbDieuKhien.Enabled = false;
            KetNoi();
        }

        private void HienThi()
        {
            if(MiniFarm.BatTatHeThong==true)
            {
                txtCheDoCTHienTai.Text = "ON";
                txtCheDoCTHienTai.BackColor = Color.LightGreen;
            }
            else
            {
                txtCheDoCTHienTai.Text = "OFF";
                txtCheDoCTHienTai.BackColor = Color.Orange;
            }
            if(MiniFarm.CheDoHeThong==-1)
            {
                txtAutoManu.Text = "OFF";
                txtAutoManu.BackColor = Color.Orange;
            }
            else if (MiniFarm.CheDoHeThong == 0)
            {
                txtAutoManu.Text = "Auto";
                txtAutoManu.BackColor = Color.LightGreen;
                tpAutoManual.Text = "Auto";
                lblAutoManual.Text = "CHẾ ĐỘ HOẠT ĐỘNG TỰ ĐỘNG";
            }
            else
            {
                txtAutoManu.Text = "Manual";
                txtAutoManu.BackColor = Color.LightBlue;
                tpAutoManual.Text = "Manual";
                lblAutoManual.Text = "CHẾ ĐỘ THAO TÁC BẰNG TAY - NGƯỜI THAO TÁC";
            }
            if(MiniFarm.TinhTrangToanHeThong == -1)
            {
                btnTinhTrangHienTaiTrenToanHeThong.Text = "Hệ thống có lỗi phát sinh.";
                btnTinhTrangHienTaiTrenToanHeThong.BackColor = Color.Red;
            }
            else if (MiniFarm.TinhTrangToanHeThong == 0)
            {
                btnTinhTrangHienTaiTrenToanHeThong.Text = "Hệ thống đang hoạt động bình thường.";
                btnTinhTrangHienTaiTrenToanHeThong.BackColor = Color.LightGreen;
            }
            else if (MiniFarm.TinhTrangToanHeThong == 1)
            {
                btnTinhTrangHienTaiTrenToanHeThong.Text = "Hệ thống đang khởi động...";
                btnTinhTrangHienTaiTrenToanHeThong.BackColor = Color.LightGreen;
            }
            else
            {
                btnTinhTrangHienTaiTrenToanHeThong.Text = "Hệ thống đang OFF";
                btnTinhTrangHienTaiTrenToanHeThong.BackColor = Color.Orange;
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            splitContainerManualAuto.Enabled = false;
            KhoiDongHeThong();
        }

        private void btnCheDoChuongTrinhHienTai_Click(object sender, EventArgs e)
        {
            MiniFarm.BatTatHeThong = !MiniFarm.BatTatHeThong;
            if (MiniFarm.BatTatHeThong == true)
            {
                MiniFarm.CheDoHeThong = 1; //Manual
                MiniFarm.TinhTrangToanHeThong = 1; //khoi dong he thong
            }
            else
            {
                MiniFarm.CheDoHeThong = -1; //off
                MiniFarm.TinhTrangToanHeThong = 2; //off
            }
            HienThi();
            CheDoHoatDong();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            serialPort1.WriteLine("dc11");
        }

        private void groupBox7_Enter(object sender, EventArgs e)
        {

        }

        private void btnChuyenCheDo_Click(object sender, EventArgs e)
        {
            if(MiniFarm.CheDoHeThong == 0)
            {
                MiniFarm.CheDoHeThong = 1;
            }
            else if(MiniFarm.CheDoHeThong == 1)
            {
                MiniFarm.CheDoHeThong = 0;
            }
            HienThi();
            CheDoHoatDong();            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(!serialPort1.IsOpen)
            {
                lblTrangThaiKetNoi.Text = "OffLine";
                lblTrangThaiKetNoi.BackColor = Color.Orange;
                gbDieuKhien.Enabled = false;
            }
            else
            {
                lblTrangThaiKetNoi.Text = "OnLine";
                lblTrangThaiKetNoi.BackColor = Color.LightGreen;
                if(MiniFarm.CheDoHeThong==1) gbDieuKhien.Enabled = true;
                MiniFarm.TinhTrangToanHeThong = 0;
                HienThi();          
            }
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (cobBoundRate.Text == "" || cobCOM.Text == "")
            {
                MessageBox.Show("Hãy kiểm tra lại thông tin cổng COM và BaundRate.");
            }
            else
            {
                if (serialPort1.IsOpen == true)
                {
                    NgatKetNoi();
                    txtNhan.Text = "";
                    Mess = "";
                }
                else if (serialPort1.IsOpen == false)
                {
                    KetNoi();
                }
            }
        }

        private void KetNoi()
        {
            try
            {
                if(MiniFarm.CheDoHeThong==1)
                {
                    if (cobCOM.Text == "" || cobBoundRate.Text == "")
                    {
                        MessageBox.Show("Hay chon thong tin");
                    }
                    else
                    {
                        serialPort1.PortName = cobCOM.Text;
                        serialPort1.BaudRate = Convert.ToInt32(cobBoundRate.Text);
                        serialPort1.Open();
                        btnConnect.Text = "Disconnect";
                        timer1.Enabled = true;
                    }
                }
                else if(MiniFarm.CheDoHeThong == 0)
                {
                    cobCOM.SelectedIndex = 1;
                    serialPort1.PortName = cobCOM.Text;
                    serialPort1.BaudRate = int.Parse(cobBoundRate.Text);
                    serialPort1.Open();
                    btnConnect.Text = "Disconnect";
                    timer1.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void NgatKetNoi()
        {
            timer1.Stop();
            lblTrangThaiKetNoi.Text = "OffLine";
            lblTrangThaiKetNoi.BackColor = Color.Orange;
            serialPort1.Close();
        }

        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string DataReceive = serialPort1.ReadLine().ToString().Trim();
            Mess = DataReceive + "\n" + Mess;
            try
            {
                BeginInvoke(new Action(() =>
                {
                    txtNhan.Text = Mess;
                    if (DataReceive.Length > 5)
                    {
                        HienThiLenListView(DataReceive);
                    }
                    else
                    {
                        HienThitrangThaiDongCo(DataReceive);
                    }
                }            
                ));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void HienThitrangThaiDongCo(string dataReceive)
        {
            if(dataReceive == "dc11")
            {
                lblDongCoBomNuoc.Text = "ON";
                lblDongCoBomNuoc.BackColor = Color.LightGreen;
            }
            if(dataReceive=="dc10")
            {
                lblDongCoBomNuoc.Text = "OFF";
                lblDongCoBomNuoc.BackColor = Color.Orange;
            }
            if(dataReceive=="dc21")
            {
                lblDongCoPhunSuong.Text = "ON";
                lblDongCoPhunSuong.BackColor = Color.LightGreen;
            }
            if (dataReceive == "dc20")
            {
                lblDongCoPhunSuong.Text = "OFF";
                lblDongCoPhunSuong.BackColor = Color.Orange;
            }
            if (dataReceive == "dc31")
            {
                lblDongCoLamMat.Text = "ON";
                lblDongCoLamMat.BackColor = Color.LightGreen;
            }
            if (dataReceive == "dc30")
            {
                lblDongCoLamMat.Text = "OFF";
                lblDongCoLamMat.BackColor = Color.Orange;
            }
            if (dataReceive == "dc41")
            {
                lblDongCoQuatHut.Text = "ON";
                lblDongCoQuatHut.BackColor = Color.LightGreen;
            }
            if (dataReceive == "dc40")
            {
                lblDongCoQuatHut.Text = "OFF";
                lblDongCoQuatHut.BackColor = Color.Orange;
            }
        }

        private void HienThiLenListView(string dataReceive)
        {
            try
            {
                string[] ValueString = dataReceive.Split('-'); // Tách chuỗi ra các cụm cảm biến.
                lvCamBien.Items.Clear();
                List<int> LsAirTem = new List<int>();
                List<int> LsAirHumi = new List<int>();
                List<int> LsSoilHumi = new List<int>();
                for (int i = 0; i < ValueString.Length; i++)
                {
                    string[] Value = ValueString[i].Split('.');
                    int SoilSenSorValue = int.Parse(Value[0]);
                    SoilSenSorValue = (SoilSenSorValue * 100) / 1023;
                    LsSoilHumi.Add(SoilSenSorValue);
                    int DHTTem = int.Parse(Value[1]);
                    LsAirTem.Add(DHTTem);
                    int DHTHumi = int.Parse(Value[2]);
                    LsAirHumi.Add(DHTHumi);
                    string s = (i + 1) + "";
                    ListViewItem lvi = new ListViewItem(s);
                    lvi.SubItems.Add(DHTTem + "");
                    lvi.SubItems.Add(DHTHumi + "");
                    lvi.SubItems.Add(SoilSenSorValue + "");
                    lvCamBien.Items.Add(lvi);
                }
                ListViewItem lviLast = new ListViewItem(DateTime.Now.ToString("HH:mm:ss"));
                lvCamBien.Items.Add(lviLast);
                MiniFarm.AddAirHumi(LsAirHumi);
                MiniFarm.AddAirTem(LsAirTem);
                MiniFarm.AddSoilHumi(LsSoilHumi);
                GhiDuLieuXuongSQL();
                KiemTraDieuKhienDongCo();
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void GhiDuLieuXuongSQL()
        {
            Sensor ss = new Sensor();
            ss.AirTem = MiniFarm.Arvage_AirTem();
            ss.AirHumi = MiniFarm.Arvage_AirHumi();
            ss.SoilHumi = MiniFarm.Arvage_SoilHumi();
            new SensorBLL().GhiDuLieuSensor(ss);
        }

        private void KiemTraDieuKhienDongCo()
        {
            if(MiniFarm.CheDoHeThong == 0) //auto
            {
                if (MiniFarm.HeThongDangHoatDongBinhThuong())
                {
                    return;
                }
                //////////////////////////
                if (MiniFarm.Arvage_AirHumi() < 50)
                {
                    serialPort1.WriteLine("dc21");                    
                }
                if(MiniFarm.Arvage_AirHumi()>=50)
                {
                    serialPort1.WriteLine("dc20");
                }
                ////////////////////////
                if (MiniFarm.Arvage_AirTem() > 40)
                {
                    serialPort1.WriteLine("dc31");
                    serialPort1.WriteLine("dc41");
                }
                if (MiniFarm.Arvage_AirTem() <= 40)
                {
                    serialPort1.WriteLine("dc30");
                    serialPort1.WriteLine("dc40");
                }
                ///////////////////////////
                if (MiniFarm.Arvage_SoilHumi() < 50)
                {
                    serialPort1.WriteLine("dc11");
                }
                if(MiniFarm.Arvage_SoilHumi() >= 50)
                {
                    serialPort1.WriteLine("dc10");
                }
            }
            else if(MiniFarm.CheDoHeThong == 1) //manual
            {
                if(MiniFarm.HeThongDangHoatDongBinhThuong())
                {
                    txtKhuyenNghi.Text = "";
                    txtKhuyenNghi.BackColor = Color.WhiteSmoke;
                    return;
                }
                if(MiniFarm.Arvage_AirHumi()<25)
                {
                    txtKhuyenNghi.Text = "Độ ẩm không khí nhỏ hơn 25%. Hãy bật động cơ phun.";
                    txtKhuyenNghi.BackColor = Color.Orange;
                }
                if(MiniFarm.Arvage_AirTem()>40)
                {
                    txtKhuyenNghi.Text ="Nhiệt độ không khí cao hơn 40 độ. Hãy bật động cơ làm mát và quạt hút";
                    txtKhuyenNghi.BackColor = Color.Orange;
                }
                if(MiniFarm.Arvage_SoilHumi()<25)
                {
                    txtKhuyenNghi.Text = "Độ ẩm đất nhỏ hơn 25%. Hay bật động cơ bơm tưới nước.";
                    txtKhuyenNghi.BackColor = Color.Orange;
                }
            }
        }

        private void txtGui_Enter(object sender, EventArgs e)
        {
            MessageBox.Show(txtGui.Text);
        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            serialPort1.WriteLine(txtGui.Text);
            txtGui.Text = "";
        }

        private void lblDongCoBomNuoc_Click(object sender, EventArgs e)
        {
           
        }

        private void btnDongCoBomNuocOff_Click(object sender, EventArgs e)
        {
            serialPort1.WriteLine("dc10");
        }

        private void btnDongCoPhunSuongOff_Click(object sender, EventArgs e)
        {
            serialPort1.WriteLine("dc20");
        }

        private void btnDongCoPhunSuongOn_Click(object sender, EventArgs e)
        {
            serialPort1.WriteLine("dc21");
        }

        private void btnDongCoLamMatOn_Click(object sender, EventArgs e)
        {
            serialPort1.WriteLine("dc31");
        }

        private void btnDongCoLamMatOff_Click(object sender, EventArgs e)
        {
            serialPort1.WriteLine("dc30");
        }

        private void btnDongCoQuatHutOn_Click(object sender, EventArgs e)
        {
            serialPort1.WriteLine("dc41");
        }

        private void btnDongCoQuatHutOff_Click(object sender, EventArgs e)
        {
            serialPort1.WriteLine("dc40");
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen) serialPort1.WriteLine("S");
        }
    }
}
