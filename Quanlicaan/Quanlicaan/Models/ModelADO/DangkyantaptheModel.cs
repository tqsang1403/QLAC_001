using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Quanlicaan.Models.ModelADO
{
    public class DangkyantaptheModel
    {
        dbConnect dbLayer = new dbConnect();
        public string HoTenNDK { get; set; }
        public string PhongBan { get; set; }
        public DateTime ngayDK { get; set; }
        public int SLCa1 { get; set; }

        public int SLCa2 { get; set; }

        public int SLCa3 { get; set; }
        public List<NhanVienModel> dsNV { get; set; } = new List<NhanVienModel>();
        public DangkyantaptheModel()
        {
        }
        public void khoiTaoDsNV(int IDPhongBan)
        {
            var res = dbLayer.Get_Employee_By_IDPhongBan(IDPhongBan);
            dsNV = new List<NhanVienModel>();
            for (int i = 0; i < res.Tables[0].Rows.Count; i++)
            {
                NhanVienModel x = new NhanVienModel();
                x.HoTen = Convert.ToString(res.Tables[0].Rows[i]["HoTen"]);
                x.ID = Convert.ToInt32(res.Tables[0].Rows[i]["ID"]);
                x.IDPhongBan = Convert.ToInt32(res.Tables[0].Rows[i]["IDPhongBan"]);
                x.username = Convert.ToString(res.Tables[0].Rows[i]["username"]);
                x.upassword = Convert.ToString(res.Tables[0].Rows[i]["upassword"]);
                x.username = Convert.ToString(res.Tables[0].Rows[i]["username"]);
                x.IDrole = Convert.ToInt32(res.Tables[0].Rows[i]["IDRole"]);
                x.RoleRegist = Convert.ToString(res.Tables[0].Rows[i]["RoleRegist"]);
                x.trangthai = Convert.ToBoolean(res.Tables[0].Rows[i]["trangthai"]);
                dsNV.Add(x);
            }
        }
    }
}