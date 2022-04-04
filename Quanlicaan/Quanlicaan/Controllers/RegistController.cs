using Quanlicaan.Models;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Mvc;

namespace Quanlicaan.Controllers
{
    public class RegistController : Controller
    {
        // GET: Regist
        [HttpGet]
        public ActionResult Index()
        {
            return View(); 
        }

        [HttpPost]
        public ActionResult Index(RegisterModel nv)
        {
            if(Request.HttpMethod == "POST")
            {
                RegisterModel re = new RegisterModel();
                using (SqlConnection con = new SqlConnection("Data Source=DESKTOP-UFFEN86;Integrated Security=true;Initial Catalog=QuanLiCaAn"))
                {
                    using( SqlCommand cmd =  new SqlCommand("Sp_RegisterUser", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                         cmd.Parameters.AddWithValue("@hoTen", nv.hoTen);
                        cmd.Parameters.AddWithValue("@username", nv.username);
                        cmd.Parameters.AddWithValue("@password", nv.password);
                        cmd.Parameters.AddWithValue("@trangThai", re.trangThai);
                        cmd.Parameters.AddWithValue("@quyenDangKy",nv.quyenDangKy);
                        cmd.Parameters.AddWithValue("@idPhongBan", nv.IDPhongBan);
                        cmd.Parameters.AddWithValue("@idRole", nv.idPhanQuyen);
                        con.Open();
                        ViewData["result"] = cmd.ExecuteNonQuery();
                        con.Close();

                    }
                }
            }
            return View(); 
        }

    }
}


