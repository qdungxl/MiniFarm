using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BLL
{
    public class UserBLL
    {
        public User TimUser(string UserName)
        {
            return new UserDAL().TimUser(UserName);
        }
        public bool KiemTraThongTinDangNhap(User us)
        {
            User usDAL = new UserDAL().TimUser(us.UserName);
            if(usDAL.PassWord==us.PassWord) return true;
            return false;
        }
        public List<User> LayToanBoSanPham()
        {
            return new UserDAL().LayToanBoSanPham();
        }
    }
}
