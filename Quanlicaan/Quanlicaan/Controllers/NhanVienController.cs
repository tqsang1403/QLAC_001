using Quanlicaan.Models.ModelADO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Quanlicaan.Controllers
{
    public class NhanVienController : Controller
    {
        // GET: NhanVien
        string connectionString = @"Data Source=ADMIN-PC;Initial Catalog=QuanLiCaAn;Integrated Security=True";

        [HttpGet]
        public ActionResult Index()
        {
            DataTable dtblNhanVien = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("Select * from NhanVien", conn);
                sqlDataAdapter.Fill(dtblNhanVien);
            }
            return View(dtblNhanVien);
        }

        

        [HttpGet]

        // GET: NhanVien/Create
        public ActionResult Create()
        {
            return View(new NhanVienModel());
        }

        // POST: NhanVien/Create
        [HttpPost]
        public ActionResult Create(NhanVienModel nhanvienModel)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "insert into NhanVien(HoTen,GioiTinh,DiaChi,SDT, IDPhongBan,IDRole, ChucVu, username, upassword, trangthai, RoleRegist) values(@HoTen, @GioiTinh, @DiaChi,@SDT, @IDPhongBan,@IDRole, @ChucVu, @username, @upassword, @trangthai,@RoleRegist)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@HoTen", nhanvienModel.HoTen);
                    cmd.Parameters.AddWithValue("@GioiTinh", nhanvienModel.GioiTinh);
                    cmd.Parameters.AddWithValue("@DiaChi", nhanvienModel.DiaChi);
                    cmd.Parameters.AddWithValue("@SDT", nhanvienModel.SDT);
                    cmd.Parameters.AddWithValue("@IDPhongBan", nhanvienModel.IDPhongBan);
                    cmd.Parameters.AddWithValue("@IDRole", nhanvienModel.IDrole);
                    cmd.Parameters.AddWithValue("@ChucVu", nhanvienModel.ChucVu);
                    cmd.Parameters.AddWithValue("@username", nhanvienModel.username);
                    cmd.Parameters.AddWithValue("@upassword", nhanvienModel.upassword);
                    cmd.Parameters.AddWithValue("@trangthai", nhanvienModel.trangthai);
                    cmd.Parameters.AddWithValue("@RoleRegist", nhanvienModel.RoleRegist);
                    cmd.ExecuteNonQuery();
                }
                catch(Exception ex)
                {
                    return Content("<script language='javascript' type='text/javascript'>alert(' Thêm mới thất bại ! Không được để trống');</script>");
                }
            }

            return RedirectToAction("Index");
        }






        // GET: NhanVien/Edit/5
        public ActionResult Edit(int id)
        {
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
                NhanVienModel.username = Convert.ToString(dtblNhanVien.Rows[0][8].ToString());
                NhanVienModel.upassword = Convert.ToString(dtblNhanVien.Rows[0][9].ToString());
                NhanVienModel.trangthai = Convert.ToBoolean(dtblNhanVien.Rows[0][10].ToString());
                NhanVienModel.RoleRegist = Convert.ToString(dtblNhanVien.Rows[0][11].ToString());
                return View(NhanVienModel);
            }
            else
                return RedirectToAction("Index");


        }

        // POST: NhanVien/Edit/5
        [HttpPost]
        public ActionResult Edit(NhanVienModel NhanVienModel)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "Update NhanVien Set HoTen = @HoTen, GioiTinh = @Gioitinh, DiaChi = @Diachi, SDT = @SDT, IDPhongBan = @IDPhongBan, ChucVu = @ChucVu, username = @username, upassword = @upassword, trangthai = @trangthai, RoleRegist = @RoleRegist where ID = @ID ";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ID", NhanVienModel.ID);
                cmd.Parameters.AddWithValue("@HoTen", NhanVienModel.HoTen);
                cmd.Parameters.AddWithValue("@GioiTinh", NhanVienModel.GioiTinh);
                cmd.Parameters.AddWithValue("@DiaChi", NhanVienModel.DiaChi);
                cmd.Parameters.AddWithValue("@SDT", NhanVienModel.SDT);
                cmd.Parameters.AddWithValue("@IDPhongBan", NhanVienModel.IDPhongBan);
                cmd.Parameters.AddWithValue("@IDRole", NhanVienModel.IDrole);
                cmd.Parameters.AddWithValue("@ChucVu", NhanVienModel.ChucVu);
                cmd.Parameters.AddWithValue("@username", NhanVienModel.username);
                cmd.Parameters.AddWithValue("@upassword", NhanVienModel.upassword);
                cmd.Parameters.AddWithValue("@trangthai", NhanVienModel.trangthai);
                cmd.Parameters.AddWithValue("@RoleRegist", NhanVienModel.RoleRegist);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            

            return RedirectToAction("Index");
        }

        // GET: NhanVien/Delete/5
        public ActionResult Delete(int id)
        {


            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "Delete from NhanVien where ID = @ID ";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ID", id);

                cmd.ExecuteNonQuery();
            }

            return RedirectToAction("Index");
        }
    }
}
