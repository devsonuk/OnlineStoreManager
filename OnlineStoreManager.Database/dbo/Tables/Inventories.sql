CREATE TABLE [dbo].[Inventories]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [ProductId] INT NOT NULL, 
    [Quantity] INT NOT NULL DEFAULT 1, 
    [PurchasePrice] MONEY NOT NULL, 
    [CreatedAt] DATETIME2 NOT NULL DEFAULT getutcdate(), 
    [UpdatedAt] DATETIME2 NULL, 
    CONSTRAINT [FK_Inventories_ToProducts] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Products]([Id])
)
