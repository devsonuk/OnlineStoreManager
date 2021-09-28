CREATE PROCEDURE [dbo].[usp_GetUser] @Id NVARCHAR(128)
AS
BEGIN
	SET NOCOUNT ON;

	SELECT Id
		,FirstName
		,LastName
		,EmailAddress
		,CreatedAt
		,UpdatedAt
	FROM [dbo].Users
	WHERE Id = @Id
END
