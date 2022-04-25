create proc Sp_Get_Employee_By_IDPhongBan
@IDPhongBan int
as 
begin
	select * from NhanVien where IDPhongBan = @IDPhongBan
end
select * from NhanVien