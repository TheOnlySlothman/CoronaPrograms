create or alter procedure ItemToInventory
	@playerId int,
	@itemId int
as
	if ((select item1 from Inventory where Inventory.Id = @playerId) = null)
		update Inventory
		set Item1 = @itemId
		where Id = @playerId
	else if ((select item2 from Inventory where Inventory.Id = @playerId) = null)
		update Inventory
		set Item2 = @itemId
		where Id = @playerId

	if ((select item1 from Inventory where Inventory.Id = @playerId) = null)
		print '1';
	else if ((select item2 from Inventory where Inventory.Id = @playerId) = null)
		print '2';
	else
		print '0';

execute ItemToInventory @playerId = 1, @itemId = 2