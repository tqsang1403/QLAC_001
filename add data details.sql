use QuanLiCaAn;
go

insert into PhongBan(TenPB)
values
	(N'Kế toán'),
	(N'Dân sự'),
	(N'Kỹ thuật')


INSERT INTO NhanVien(HoTen,GioiTinh,DiaChi,SDT,IDPhongBan,ChucVu, username,upassword, trangthai)
values
(N'Trần Quang Sang',1,N'Hải Dương','0356203601','1',N'Giám đốc','sang','123456',1),
(N'Nguyễn Xuân Hưng',1,N'Hải Dương','0320502420','2',N'Nhân viên','hung','123456',1),
(N'Nguyễn Tuấn Thành',1,N'Nam Định','0923004201','3',N'Kế toán','thanh','123456',1),
(N'Nguyễn Hoàng Hiệp',1,N'Thanh Hóa','092314124','2',N'Dân sự','hiep','123456',1),
(N'Lê Văn Toàn',1,N'Nam Định','0321412124','1',N'Nhân viên','toan','123456',1)

select * from NhanVien
delete from NhanVien
insert into Roles(URole)
values
(N'Admin'),
(N'User')

insert into CaAn(Thoigian)
values
('3-2-2022 9:00:00 AM'),
('3-2-2022 15:00:00 PM')


select * from CaAn

SELECT CONVERT(VARCHAR(9),RIGHT(Thoigian,9),108) FROM CaAn

delete  from CaAn
alter table CaAn
drop column ID 

INSERT INTO SuatAn
values	
('11',getdate()),
('12',getdate()),
('13',getdate())

select * from SuatAn


insert into ChiTietSuatAn(IDUser,Soluong,IDSuatAn,IDCaan,Thoigiandat)
values
('11','1','3','1',getdate()),
('12','1','3','2',getdate()),
('13','1','4','2',getdate())

select * from ChiTietSuatAn


