
using Quanlicaan.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Quanlicaan.Models
{
    public class DangKyTapTheModel
    {
        db dbLayer = new db();
        public string hoTenNDK { get; set; }
        public string phongBan { get; set; }
        public DateTime ngayDK { get; set; }
        public List<NhanVienModel> dsNV { get; set; } = new List<NhanVienModel>();
        public DangKyTapTheModel()
        {
        }
        public void khoiTaoDsNV(int IDPhongBan)
        {
            var res = dbLayer.Get_Employee_By_IDPhongBan(IDPhongBan);
            dsNV = new List<NhanVienModel>();
            for (int i = 0; i < res.Tables[0].Rows.Count; i++)
            {
                NhanVienModel x = new NhanVienModel();
                x.hoTen = Convert.ToString(res.Tables[0].Rows[i]["hoTen"]);
                x.ID = Convert.ToInt32(res.Tables[0].Rows[i]["ID"]);
                x.IDPhongBan = Convert.ToInt32(res.Tables[0].Rows[i]["IDPhongBan"]);
                x.username = Convert.ToString(res.Tables[0].Rows[i]["username"]);
                x.password = Convert.ToString(res.Tables[0].Rows[i]["upassword"]);
                x.username = Convert.ToString(res.Tables[0].Rows[i]["username"]);
                x.IDRole = Convert.ToInt32(res.Tables[0].Rows[i]["IDRole"]);
                x.quyen = Convert.ToString(res.Tables[0].Rows[i]["quyen"]);
                x.trangThai = Convert.ToBoolean(res.Tables[0].Rows[i]["trangThai"]);
                dsNV.Add(x);
            }
        }
       
    }
}