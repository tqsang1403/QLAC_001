using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Quanlicaan.Models.ModelADO
{
    public class NhanVien
    {
      

        public int ID { get; set; }

        
        public string HoTen { get; set; }

        public bool GioiTinh { get; set; }

        
        public string DiaChi { get; set; }

        
        public string SDT { get; set; }

        public int IDPhongBan { get; set; }

    
        public string ChucVu { get; set; }

     
        public string username { get; set; }

   
        public string upassword { get; set; }

        public bool trangthai { get; set; }

        public int? IDrole { get; set; }
    }
}