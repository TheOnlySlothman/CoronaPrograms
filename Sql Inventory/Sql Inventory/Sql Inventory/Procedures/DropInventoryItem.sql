create or alter procedure DropInventoryItem
	@playerId int,
	@inventoryId int
as
	declare @itemSlot varchar(5)
	declare @sql nvarchar(1000)
	if (@inventoryId = 1)
		set @itemSlot = 'Item1'
	else if (@inventoryId = 2)
		set @itemSlot = 'Item2'
	else if (@inventoryId = 3)
		set @itemSlot = 'Item3'
	else if (@inventoryId = 4)
		set @itemSlot = 'Item4'
	else if (@inventoryId = 5)
		set @itemSlot = 'Item5'

		execute('update Inventory set ' + @itemSlot + ' = null where Id = ' + @playerId)
		