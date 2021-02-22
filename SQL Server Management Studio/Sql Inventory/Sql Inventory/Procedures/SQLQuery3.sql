use testDB

declare @playerId int
declare @itemId int

set @playerId = 2
set @itemId = 2

declare @temp nvarchar(15)
set @temp = (select item1 from Inventory where Inventory.Id = @playerId)
print @temp

if ((select item1 from Inventory where Inventory.Id = @playerId) is null)
	print '1';
else if ((select item2 from Inventory where Inventory.Id = @playerId) is null)
	print '2';
else
	print '0';

if ((select item1 from Inventory where Inventory.Id = @playerId) is null)
	update Inventory
	set Item1 = @itemId
	where Id = @playerId
else if ((select item2 from Inventory where Inventory.Id = @playerId) is null)
	update Inventory
	set Item2 = @itemId
	where Id = @playerId