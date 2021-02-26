create or alter trigger CreatePlayerInventory
on Players
for insert
as
	Declare @PlayerId int
	set @PlayerId = (select Id from inserted)
	insert into Inventory values(@PlayerId, null, null, null, null, null)