USE [QuanLiCaAn]
GO
/****** Object:  StoredProcedure [dbo].[spLogin]    Script Date: 3/29/2022 11:50:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER proc [dbo].[spLogin]	(@username char(10),
	@upassword char(10))
as
begin
	declare @count int
	declare @res bit
	select @count = count(*) from NhanVien where username = @username and upassword = @upassword
	if @count > 0
		set @res = 1
	else
		set @res = 0
		select @res
end