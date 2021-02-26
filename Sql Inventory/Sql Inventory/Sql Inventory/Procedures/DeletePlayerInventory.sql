create or alter trigger DeletePlayerInventory
on Players
for delete
as
	Declare @PlayerId int
	set @PlayerId = (select Id from deleted)
	delete from Inventory where Id = @PlayerId

delete from Players where id = 1