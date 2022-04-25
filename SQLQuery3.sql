USE [QuanLiCaAn]
GO

DECLARE	@return_value int

EXEC	@return_value = [dbo].[Sp_DangKyCaNhan]
		@hoTen = N'trần xuân độ',
		@phongBan = N'kế toán',
		@ngayDK = '2022-11-10 09:31:00',
		@SLCa1 = 1,
		@SLCa2 = 1,
		@SLCa3 = 1

SELECT	'Return Value' = @return_value

GO
