use testDB

create or alter trigger GenderLimitter
on Genders
for insert
as
	Declare @GenderId int
	set @GenderId = (select Id from inserted)
	if (@GenderId > 1)
		raiserror ('table cant hold more than 2 genders', 1, @GenderId) 
		return

insert into Genders values (2, 'U')

create or alter trigger PersonSaver
on Person
for delete
as
	select * from deleted

delete from Person where Id = 1

create or alter trigger CreatePlayerInventory
on Players
for insert
as
	Declare @PlayerId int
	set @PlayerId = (select Id from inserted)
	insert into Inventory values(@PlayerId, null, null, null, null, null)

create or alter trigger DeletePlayerInventory
on Players
for delete
as
	Declare @PlayerId int
	set @PlayerId = (select Id from deleted)
	delete from Inventory where Id = @PlayerId

delete from Players where id = 1
