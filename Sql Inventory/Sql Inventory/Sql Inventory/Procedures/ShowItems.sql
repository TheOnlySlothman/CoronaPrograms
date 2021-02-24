create or alter procedure ShowItems
as
	select Items.Id, Items.Name, ITypes.Name as TypeName, Items.Weight
	from Items
	join ITypes on Items.TypeId = ITypes.Id