create or alter procedure UpdateItem
	@playerId int,
	@inventoryId int,
	@itemId int
as
	if (@inventoryId = 1)
		update Inventory
		set Item1 = @itemId
		where Id = @playerId
	else if (@inventoryId = 2)
		update Inventory
		set Item2 = @itemId
		where Id = @playerId
	else if (@inventoryId = 3)
		update Inventory
		set Item3 = @itemId
		where Id = @playerId
	else if (@inventoryId = 4)
		update Inventory
		set Item4 = @itemId
		where Id = @playerId
	else if (@inventoryId = 5)
		update Inventory
		set Item5 = @itemId
		where Id = @playerId