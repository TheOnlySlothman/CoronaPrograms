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
on Persons
for delete
as
	select * from deleted
