﻿using Quanlicaan.Models.ModelsPage;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Quanlicaan.Models.DAO
{
    public class ThongkeModels
    {
        public SqlConnection conn = ConnectDb.ConnectionDb();
        public SqlCommand command = new SqlCommand();
        public SqlDataAdapter dataAdapter = new SqlDataAdapter();
        public DataSet ds = new DataSet();

        public ThongkeModels()
        {
            conn.Open();
            command.Connection = conn;
        }

        //lấy ra danh suât ăn người dùng đã dăng kí  danh sách suất ăn gồm suât ăn cá nhân với suất ăn tập thể
        public DataSet LayDSsuatan(int idUser)
        {

            command.CommandText = "select NhanVien.HoTen as N'Tên nhân viên đăng kí', a.* from( select SuatAn.IDUser as IDnhanviendangki , SuatAn.Loaisuatan , SuatAn.Thoigiandat, ChiTietSuatAn.* , NhanVien.HoTen from ChiTietSuatAn inner join NhanVien on NhanVien.ID = ChiTietSuatAn.IDUser inner join SuatAn on ChiTietSuatAn.IDSuatAn = SuatAn.ID where ChiTietSuatAn.IDUser in ( select ChiTietSuatAn.IDUser from SuatAn inner join NhanVien on SuatAn.IDUser = NhanVien.ID inner join ChiTietSuatAn on ChiTietSuatAn.IDSuatAn = SuatAn.ID where ChiTietSuatAn.IDUser = @iduser) ) as a inner join NhanVien on  NhanVien.ID = a.IDnhanviendangki order by a.Thoigiandat desc";

            command.Parameters.AddWithValue("@iduser", idUser);
            dataAdapter.SelectCommand = command;
            dataAdapter.Fill(ds, "Baocaocanhan");
            command.Parameters.Clear();
            conn.Close();

            return ds;
        }


        // lấy ra danh sách suất ăn theo ngày được chọn
        public List<BaocaocanhanModelPage> LayDSsuatan(int idUser , DateTime day)
        {

            command.CommandText = " select NhanVien.HoTen as N'Tên nhân viên đăng kí', a.* from( select SuatAn.IDUser as IDnhanviendangki , SuatAn.Loaisuatan , SuatAn.Thoigiandat, ChiTietSuatAn.* , NhanVien.HoTen from ChiTietSuatAn inner join NhanVien on NhanVien.ID = ChiTietSuatAn.IDUser inner join SuatAn on ChiTietSuatAn.IDSuatAn = SuatAn.ID where ChiTietSuatAn.IDUser in ( select ChiTietSuatAn.IDUser from SuatAn inner join NhanVien on SuatAn.IDUser = NhanVien.ID inner join ChiTietSuatAn on ChiTietSuatAn.IDSuatAn = SuatAn.ID where ChiTietSuatAn.IDUser = 1) ) as a inner join NhanVien on  NhanVien.ID = a.IDnhanviendangki  where ChiTietSuatAn.IDUser = 1) ) as a inner join NhanVien on  NhanVien.ID = a.IDnhanviendangki where Thoigiandat  between CONVERT(datetime, CONVERT(date, @day)) and CONVERT(datetime, CONVERT(date, dateadd(day,1,@day))) order by a.Thoigiandat desc";
            command.Parameters.AddWithValue("@iduser", idUser);
            command.Parameters.AddWithValue("@day", day);
            dataAdapter.SelectCommand = command;
            dataAdapter.Fill(ds, "Baocaocanhantheongay");
            command.Parameters.Clear();
            conn.Close();
            List<BaocaocanhanModelPage> list = new List<BaocaocanhanModelPage>();
            foreach (DataRow dr in ds.Tables["Baocaocanhantheongay"].Rows)
            {
                if (ds.Tables[0].Rows.Count != 0)
                {


                    BaocaocanhanModelPage model = new BaocaocanhanModelPage();
                    model.IDUser = Convert.ToInt32(dr["IDnhanviendangki"]);
                    model.Hotennguoidangki = dr["Tên nhân viên đăng kí"].ToString();
                    model.LoaiSuatan = Convert.ToInt32(dr["Loaisuatan"]);
                    model.Thoigiandangki = Convert.ToDateTime(dr["Thoigiandat"]);
                    model.MaSuatan = Convert.ToInt32(dr["IDSuatAn"]);
                    model.MaCTSuatan = Convert.ToInt32(dr["ID"]);
                    model.MaCaan = Convert.ToInt32(dr["IDCaan"]);
                    model.Hotennguoidungsuatan = dr["HoTen"].ToString();
                    model.Soluong = Convert.ToInt32(dr["Soluong"]);
                    model.Thoigiancapnhat = Convert.ToDateTime(dr["Thoigiancapnhat"]);
                    model.Hotennguoicapnhat = dr["Tennhanviencapnhat"].ToString();
                    model.Thantien = Convert.ToInt32(dr["Soluong"]) * 15000;


                    list.Add(model);
                }
                else
                {
                    list = null;
                }
            }
            return list;
        }
    }
}