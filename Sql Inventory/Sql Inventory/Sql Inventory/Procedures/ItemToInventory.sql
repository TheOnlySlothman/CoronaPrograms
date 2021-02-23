create or alter procedure ItemToInventory
	@playerId int,
	@itemId int
as
	if ((select item1 from Inventory where Inventory.Id = @playerId) is null)
		update Inventory
		set Item1 = @itemId
		where Id = @playerId
	else if ((select item2 from Inventory where Inventory.Id = @playerId) is null)
		update Inventory
		set Item2 = @itemId
		where Id = @playerId
	else if ((select item3 from Inventory where Inventory.Id = @playerId) is null)
		update Inventory
		set Item3 = @itemId
		where Id = @playerId
	else if ((select item4 from Inventory where Inventory.Id = @playerId) is null)
		update Inventory
		set Item4 = @itemId
		where Id = @playerId
	else if ((select item5 from Inventory where Inventory.Id = @playerId) is null)
		update Inventory
		set Item5 = @itemId
		where Id = @playerId