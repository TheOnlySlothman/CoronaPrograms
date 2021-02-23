use testDB

select Players.Id, Players.Name, Classes.Name as class, Items.Name as item1 
from Players
inner join Classes on Players.ClassId = Classes.Id
inner join Inventory on Inventory.Id = Players.Id
left join Items on Inventory.Item1 = Items.Id