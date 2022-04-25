/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP (1000) [ID]
      ,[IDUser]
      ,[Soluong]
      ,[IDSuatAn]
      ,[IDCaan]
  FROM [QuanLiCaAn].[dbo].[ChiTietSuatAn]
  DELETE FROM ChiTietSuatAn