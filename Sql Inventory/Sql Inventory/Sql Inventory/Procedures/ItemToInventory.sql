create or alter procedure ItemToInventory
	@playerId int,
	@itemId int
as
	declare @itemSlot varchar(5)
	declare @sql nvarchar(1000)
	if ((select item1 from Inventory where Inventory.Id = @playerId) is null)
		set @itemSlot = 'Item1'
	else if ((select item2 from Inventory where Inventory.Id = @playerId) is null)
		set @itemSlot = 'Item2'
	else if ((select item3 from Inventory where Inventory.Id = @playerId) is null)
		set @itemSlot = 'Item3'
	else if ((select item4 from Inventory where Inventory.Id = @playerId) is null)
		set @itemSlot = 'Item4'
	else if ((select item5 from Inventory where Inventory.Id = @playerId) is null)
		set @itemSlot = 'Item5'

	execute('update Inventory set ' + @itemSlot + ' = ' + @itemId + ' where Id = ' + @playerId);