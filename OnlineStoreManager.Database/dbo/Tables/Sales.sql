CREATE TABLE [dbo].[Sales]
(
	[CashierId] NVARCHAR(128) NOT NULL PRIMARY KEY, 
    [SubTotal] MONEY NOT NULL, 
    [Tax] MONEY NOT NULL, 
    [Total] MONEY NOT NULL,
    [CreatedAt] DATETIME2 NOT NULL,
    [UpdatedAt] DATETIME2 NULL DEFAULT getutcdate(),

)
