USE CRM;
GO
CREATE PROCEDURE DBO.DV_GET_DIADIEM_ATM
@ATMID NVARCHAR(10)
AS
SELECT 
DIADIEM
FROM ATM
WHERE ID = @ATMID