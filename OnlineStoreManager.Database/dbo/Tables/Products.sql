CREATE TABLE [dbo].[Products]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NCHAR(100) NOT NULL, 
    [Description] NVARCHAR(MAX) NOT NULL, 
    [RetailPrice] MONEY NOT NULL, 
    [QuantityInStock] INT NOT NULL DEFAULT 1,
    [CreatedAt] DATETIME2 NOT NULL DEFAULT getutcdate(), 
    [UpdatedAt] DATETIME2 NULL
)
