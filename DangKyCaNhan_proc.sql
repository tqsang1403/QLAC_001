create proc Sp_DangKyCaNhan
@hoTen nvarchar(max),
@phongBan nvarchar(30),
@ngayDK datetime,
@SLCa1 int,
@SLCa2 int,
@SLCa3 int
as 
begin
	declare @IDNhanVien int, @IDPhongBan int, @IDSuatAn int;
	set @IDPhongBan = (select ID from PhongBan where TenPB = @phongBan);
	set @IDNhanVien = (select ID from NhanVien where hoTen = @hoTen and IDPhongBan = @phongBan);
	insert into SuatAn(IDUser, Thoigiandat) values(@IDNhanVien, @ngayDK);
	set @IDSuatAn = (select ID from SuatAn where IDUser = @IDNhanVien and Thoigiandat = @ngayDK);
	insert into ChiTietSuatAn (IDUser, Soluong, IDSuatAn, IDCaan)
	values(@IDNhanVien, @SLCa1, @IDSuatAn,1);
	insert into ChiTietSuatAn (IDUser, Soluong, IDSuatAn, IDCaan)
	values(@IDNhanVien, @SLCa2, @IDSuatAn,1);
	insert into ChiTietSuatAn (IDUser, Soluong, IDSuatAn, IDCaan)
	values(@IDNhanVien, @SLCa3, @IDSuatAn,1);
end