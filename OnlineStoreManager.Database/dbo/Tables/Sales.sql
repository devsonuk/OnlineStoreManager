CREATE TABLE [dbo].[Sales]
(
    [Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[CashierId] INT NOT NULL, 
    [SubTotal] MONEY NOT NULL, 
    [Tax] MONEY NOT NULL, 
    [Total] MONEY NOT NULL,
    [CreatedAt] DATETIME2 NOT NULL DEFAULT getutcdate(),
    [UpdatedAt] DATETIME2 NULL, 
    CONSTRAINT [FK_Sales_ToUsers] FOREIGN KEY ([CashierId]) REFERENCES [dbo].[Users]([Id])

)
