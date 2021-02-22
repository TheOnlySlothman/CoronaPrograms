create or alter procedure DropItem
	@playerId int,
	@itemId int
as
	if (@itemId = 1)
		update Inventory
		set Item1 = null
		where Id = @playerId
	else if (@itemId = 2)
		update Inventory
		set Item2 = null
		where Id = @playerId
	else if (@itemId = 3)
		update Inventory
		set Item3 = null
		where Id = @playerId
	else if (@itemId = 4)
		update Inventory
		set Item4 = null
		where Id = @playerId
	else if (@itemId = 5)
		update Inventory
		set Item5 = null
		where Id = @playerId