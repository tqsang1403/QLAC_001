use QuanLiCaAn
go

ALTER TABLE NhanVien
   ADD CONSTRAINT FK_NhanVien_Roles FOREIGN KEY (IDRole)
      REFERENCES Roles(ID)
      ON DELETE CASCADE
      ON UPDATE CASCADE


ALTER TABLE Roles
ADD CONSTRAINT fk_IDRole_NV
FOREIGN KEY (ID) 
REFERENCES NhanVien (IDRole) ON UPDATE CASCADE 

ALTER TABLE NhanVien
ALTER COLUMN IDRole int not null

select ID from Roles
WHERE ID NOT IN
(SELECT IDRole from NhanVien)

select * from NhanVien

alter table NhanVien
Drop column IDRole

alter table NhanVien add foreign key (IDRole) references Roles (ID)


alter table NhanVien
add IDrole int foreign key references Roles(ID)