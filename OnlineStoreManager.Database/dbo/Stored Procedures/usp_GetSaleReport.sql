CREATE PROCEDURE [dbo].[usp_GetSaleReport]
AS
BEGIN
	SET NOCOUNT ON;

	SELECT [s].[Id]
		,[s].[SubTotal]
		,[s].[Tax]
		,[s].[Total]
		,[s].[CreatedAt] AS 'SaleDate'
		,[U].[Id] AS 'CashierId'
		,[U].[FirstName]
		,[U].[LastName]
		,[U].[Email]
	FROM dbo.Sales S
	INNER JOIN dbo.Users U ON S.CashierId = U.Id;
END
