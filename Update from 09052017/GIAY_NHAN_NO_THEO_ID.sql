USE [AGRIBANKHD]
GO

/****** Object:  StoredProcedure [dbo].[GIAY_NHAN_NO_THEO_ID]    Script Date: 05/08/2017 13:51:25 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[GIAY_NHAN_NO_THEO_ID] 
	-- Add the parameters for the stored procedure here
	@id_giay_nhan_no int
	
AS
SELECT * FROM [dbo].[TD.GIAY_NHAN_NO] WHERE [ID_GIAY_NHAN_NO] = @id_giay_nhan_no


GO


