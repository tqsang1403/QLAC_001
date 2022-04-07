create proc Sp_PhongBan_Add
@TenPB nvarchar(30)
as
begin
	insert into PhongBan(TenPB) values(@TenPB)
end
--==================================
create proc Sp_PhongBan_All
as
begin
select * from PhongBan
end
--====================================
create proc Sp_PhongBan_Delete
@ID int
as
begin
	delete from PhongBan where ID = @ID
end
--=====================================
create proc Sp_PhongBan_Id
@ID int
as begin
select * from PhongBan where ID = @ID
end
--====================================
create proc Sp_PhongBan_Update
@TenPB nvarchar(30),
@ID int
as 
begin
	update PhongBan set TenPB = @TenPB where ID = @ID
end