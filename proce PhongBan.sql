use QuanLiCaAn
go

Create procedure addnewphongban
(  
   @TenPB nvarchar(30) 
)  
as  
begin  
   Insert into PhongBan(TenPB) values(@TenPB)  
End 


Create Procedure GetAllPB
as  
begin  
   select *from PhongBan  
End 


Create procedure UpdatePhongBan
(  
@TenPB nvarchar(30) )  
as  
begin  
   Update PhongBan   
   set TenPB=@TenPB
   
   where ID=ID
End 