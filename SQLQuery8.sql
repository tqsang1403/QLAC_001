USE [QuanLiCaAn]
GO

DECLARE	@return_value int

EXEC	@return_value = [dbo].[Sp_DangKyCaNhan]
		@hoTen = N'trần xuân độ',
		@phongBan = N'Kế toán',
		@ngayDK = '9:11:24',
		@SLCa1 = 1,
		@SLCa2 = 0,
		@SLCa3 = 1

SELECT	'Return Value' = @return_value

GO
