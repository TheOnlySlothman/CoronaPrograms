create or alter procedure DeleteItem
	@itemId int
as
	Delete from Items where Id = @itemId