USE [QuanLiCaAn]
GO

DECLARE	@return_value int

EXEC	@return_value = [dbo].[Sp_Get_Employee_By_IDPhongBan]
		@IDPhongBan = 1

SELECT	'Return Value' = @return_value

GO
