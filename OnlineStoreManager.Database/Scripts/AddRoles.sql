INSERT INTO dbo.AspNetRoles (id, Name)
VALUES (NEWID(),'Cashier')
	,(NEWID(),'Manager')
	,(NEWID(),'Admin')

select *
from dbo.AspNetRoles

select *
from dbo.AspNetUsers
