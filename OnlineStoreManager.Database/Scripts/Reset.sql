Select *
from Sales

Select *
from SaleDetails

Select *
from Inventories

Select *
from Products

Delete Sales
where id = 1003

Delete SaleDetails
where id = 1


-- Reset the index
DBCC CHECKIDENT ('[TableName]', RESEED, 0);
GO

Insert into Sales(CashierId, SubTotal, Tax, Total)
values(1, 1000, 100, 1100)


