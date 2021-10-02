CREATE TABLE [dbo].[SaleDetails]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [SaleId] INT NOT NULL, 
    [ProductId] INT NOT NULL, 
    [Quantity] INT NOT NULL DEFAULT 1, 
    [CumulativePrice] MONEY NOT NULL, 
    [Tax] MONEY NOT NULL DEFAULT 0, 
    [CreatedAt] DATETIME2 NOT NULL DEFAULT getutcdate(), 
    [UpdatedAt] DATETIME2 NULL, 
    CONSTRAINT [FK_SaleDetails_ToSales] FOREIGN KEY ([SaleId]) REFERENCES [dbo].[Sales]([Id]), 
    CONSTRAINT [FK_SaleDetails_ToProducts] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Products]([Id])
	
)
