using System;
using System.Data.SqlClient;
using System.Linq;

namespace Quanlicaan.Models
{


    public class UserModel
    {

        private Model1 context1 = null;
        public UserModel()
        {

            context1 = new Model1();

        }
        // public bool Login(string username, string upassword)
        //{
        //    object[] sqlParams =  {
        //        new SqlParameter("@username",username),
        //        new SqlParameter("@upassword", upassword),
        //    };

        //    var res =
        //        context1.Database.SqlQuery<bool>("spLogin @username, @upassword", sqlParams)
        //        .FirstOrDefault();
        //    return res;
        //}



        public int Create(String name, bool Gioitinh, String Diachi, String SDT, int IDPhongBan, String ChucVu, String username, String passsword, bool? trangthai)
        {
            object[] parameters =
            {
                new SqlParameter("@Hoten", name),
                new SqlParameter("@Gioitinh", Gioitinh),
                new SqlParameter("@Diachi", Diachi),
                new SqlParameter("@SDT", SDT),
                new SqlParameter("@IDPhongBan", IDPhongBan),
                new SqlParameter("@ChucVu", ChucVu),
              
                new SqlParameter("@username", username),
                new SqlParameter("@upassword", passsword),
               
                new SqlParameter("@trangthai", trangthai)
            };
            int res = context1.Database.ExecuteSqlCommand("spInsertUser @HoTen, @GioiTinh,	@DiaChi  ,	@SDT,	@IDPhongBan ,	@ChucVu ,	@username,	@upassword ,	@trangthai )", parameters);
            return res;

        }
    }
}