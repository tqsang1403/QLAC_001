using Quanlicaan.Models.Models._2;
using Quanlicaan.Models.Session;
using Quanlicaan.Models.ShowModels;
using Quanlicaan.Models.ModelADO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Windows.Forms;

namespace Quanlicaan.Controllers
{
    public class UserLoginController : Controller
    {
        string connectionString = @"Data Source=SANGGTRANPC;Initial Catalog=QuanLiCaAn;Integrated Security=True";
        SqlConnection conn = new SqlConnection(@"Data Source=SANGGTRANPC;Initial Catalog=QuanLiCaAn;Integrated Security=True");

        // GET: UserLogin
        public ActionResult Details(userModel usm, string thongbao)
        {
            ViewData["message"] = thongbao;
            userSession us = (userSession)Session["user"];
            if (us != null)
            {
                usm.ID = us.ID;
                usm.HoTen = us.HoTen;
                usm.GioiTinh = us.GioiTinh;
                usm.DiaChi = us.DiaChi;
                usm.ChucVu = us.ChucVu;
                usm.username = us.username;
                usm.PhongBan = us.PhongBan;
                usm.IDrole = us.IDRole;
                usm.upassword = us.upassword;
                usm.RoleRegist = us.RoleRegist;
                usm.SDT = us.SDT;
                usm.trangthai = us.trangthai;
                usm.QuyenTruyCap = us.QuyenTruyCap;

                return View(usm);
            }
            else
            {
                ViewBag.error = "Ban chua dang nhap !";
                return Redirect("~/Login/Login");
            }
        }






        // GET: UserLogin/Edit/5
        public ActionResult EditDetails(string thongbao)
        {
            ViewData["message"] = thongbao;
            userSession us = (userSession)Session["user"];

            int id = us.ID;

            var pb = new PhongBanModels();
            DataSet ds = pb.getAllPhongBan();
            ViewBag.PhongBan = ds.Tables["PhongBan"];




            NhanVienModel NhanVienModel = new NhanVienModel();
            DataTable dtblNhanVien = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "Select * from NhanVien where ID=@ID";
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, conn);
                sqlDataAdapter.SelectCommand.Parameters.AddWithValue("@ID", id);
                sqlDataAdapter.Fill(dtblNhanVien);
            }
            if (dtblNhanVien.Rows.Count == 1)
            {
                NhanVienModel.ID = Convert.ToInt32(dtblNhanVien.Rows[0][0].ToString());
                NhanVienModel.HoTen = Convert.ToString(dtblNhanVien.Rows[0][1].ToString());
                NhanVienModel.GioiTinh = Convert.ToBoolean(dtblNhanVien.Rows[0][2].ToString());
                NhanVienModel.DiaChi = Convert.ToString(dtblNhanVien.Rows[0][3].ToString());
                NhanVienModel.SDT = Convert.ToString(dtblNhanVien.Rows[0][4].ToString());
                NhanVienModel.IDPhongBan = Convert.ToInt32(dtblNhanVien.Rows[0][5].ToString());
                NhanVienModel.IDrole = Convert.ToInt32(dtblNhanVien.Rows[0][7].ToString());
                NhanVienModel.ChucVu = Convert.ToString(dtblNhanVien.Rows[0][6].ToString());

                NhanVienModel.trangthai = Convert.ToBoolean(dtblNhanVien.Rows[0][10].ToString());
                NhanVienModel.RoleRegist = Convert.ToString(dtblNhanVien.Rows[0][11].ToString());

                return View(NhanVienModel);
            }
            else
                return RedirectToAction("Details");

        }

        // POST: UserLogin/Edit/5
        [HttpPost]
        public ActionResult EditDetails(NhanVienModel NhanVienModel)
        {
            string thongbao = "";
            var pb = new PhongBanModels();
            DataSet ds = pb.getAllPhongBan();
            ViewBag.PhongBan = ds.Tables["PhongBan"];

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "Update NhanVien Set HoTen = @HoTen, GioiTinh = @Gioitinh, DiaChi = @Diachi, SDT = @SDT, IDPhongBan = @IDPhongBan where ID = @ID ";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ID", NhanVienModel.ID);
                    cmd.Parameters.AddWithValue("@HoTen", NhanVienModel.HoTen);
                    cmd.Parameters.AddWithValue("@GioiTinh", NhanVienModel.GioiTinh);
                    cmd.Parameters.AddWithValue("@DiaChi", NhanVienModel.DiaChi);
                    cmd.Parameters.AddWithValue("@SDT", NhanVienModel.SDT);
                    cmd.Parameters.AddWithValue("@IDPhongBan", NhanVienModel.IDPhongBan);


                    cmd.ExecuteNonQuery();

                    thongbao = "Sua thong tin thanh cong. Vui long dang nhap lai de cap nhat thong tin !";
                    conn.Close();

                }
                catch (System.Data.SqlClient.SqlException sqlException)
                {

                    thongbao = "Sua thong tin that bai";
                    //MessageBox.Show(sqlException.Message);
                    return RedirectToAction("EditDetails", "UserLogin", new { thongbao });
                }
            }


            return RedirectToAction("Details", "UserLogin", new { thongbao });

        }




        // GET: UserLogin/Edit/5
        public ActionResult EditAccount(string thongbao)
        {
            ViewData["message"] = thongbao;
            userSession us = (userSession)Session["user"];

            int id = us.ID;

            var pb = new PhongBanModels();
            DataSet ds = pb.getAllPhongBan();
            ViewBag.PhongBan = ds.Tables["PhongBan"];




            NhanVienModel NhanVienModel = new NhanVienModel();
            DataTable dtblNhanVien = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "Select * from NhanVien where ID=@ID";
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, conn);
                sqlDataAdapter.SelectCommand.Parameters.AddWithValue("@ID", id);
                sqlDataAdapter.Fill(dtblNhanVien);
            }
            if (dtblNhanVien.Rows.Count == 1)
            {
                NhanVienModel.ID = Convert.ToInt32(dtblNhanVien.Rows[0][0].ToString());
                NhanVienModel.username = Convert.ToString(dtblNhanVien.Rows[0][8].ToString());
                NhanVienModel.upassword = Convert.ToString(dtblNhanVien.Rows[0][9].ToString());


                return View(NhanVienModel);
            }
            else
                return RedirectToAction("Details");

        }

        // POST: UserLogin/Edit/5
        [HttpPost]
        public ActionResult EditAccount(NhanVienModel NhanVienModel)
        {
            string thongbao = "";

            userSession us = (userSession)Session["user"];
            string usernm = us.username;
            var pb = new PhongBanModels();
            DataSet ds = pb.getAllPhongBan();
            ViewBag.PhongBan = ds.Tables["PhongBan"];

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                if (NhanVienModel.OldPass == us.upassword)
                {
                    if (NhanVienModel.upassword == NhanVienModel.Retypeupassword)
                    {
                        try
                        {
                            conn.Open();
                            string query = "Update NhanVien Set username = @username, upassword = @upassword where ID = @ID ";
                            SqlCommand cmd = new SqlCommand(query, conn);
                            cmd.Parameters.AddWithValue("@ID", NhanVienModel.ID);

                            cmd.Parameters.AddWithValue("@username", usernm);
                            cmd.Parameters.AddWithValue("@upassword", NhanVienModel.upassword);

                            cmd.ExecuteNonQuery();

                            thongbao = "Thay doi mat khau thanh cong! Vui long dang nhap lai de cap nhat thong tin !";
                            conn.Close();

                        }
                        catch (System.Data.SqlClient.SqlException sqlException)
                        {

                            thongbao = "Thay doi mat khau that bai";
                            return RedirectToAction("EditAccount", "UserLogin", new { thongbao });
                        }
                    }
                    else
                    {
                        thongbao = "Mật khẩu không khớp !";
                        return RedirectToAction("EditAccount", "UserLogin", new { thongbao });
                    }
                }
                else
                {
                    thongbao = "Mật khẩu hiện tại không đúng !";
                    return RedirectToAction("EditAccount", "UserLogin", new { thongbao });
                }
            }


            return RedirectToAction("Details", "UserLogin", new { thongbao });

        }
    }
}
