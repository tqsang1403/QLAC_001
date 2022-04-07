create proc Sp_CaAn_Add
@Thoigian datetime
as
begin
	insert into CaAn(Thoigian) values(@Thoigian)
end
--==================================
create proc Sp_CaAn_All
as
begin
select * from CaAn
end
--====================================
create proc Sp_CaAn_Delete
@ID int
as
begin
	delete from CaAn where ID = @ID
end
--=====================================
create proc Sp_CaAn_Id
@ID int
as begin
select * from CaAn where ID = @ID
end
--====================================
create proc Sp_CaAn_Update
@TenPB nvarchar(30),
@ID int
as 
begin
	update CaAn set TenPB = @TenPB where ID = @ID
end