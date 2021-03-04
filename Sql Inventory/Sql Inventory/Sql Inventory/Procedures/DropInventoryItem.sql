create or alter procedure DropInventoryItem
	@playerId int,
	@inventoryId int
as
	if (@inventoryId = 1)
		update Inventory
		set Item1 = null
		where Id = @playerId
	else if (@inventoryId = 2)
		update Inventory
		set Item2 = null
		where Id = @playerId
	else if (@inventoryId = 3)
		update Inventory
		set Item3 = null
		where Id = @playerId
	else if (@inventoryId = 4)
		update Inventory
		set Item4 = null
		where Id = @playerId
	else if (@inventoryId = 5)
		update Inventory
		set Item5 = null
		where Id = @playerId