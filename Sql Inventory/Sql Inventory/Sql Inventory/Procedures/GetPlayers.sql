create or alter procedure GetPlayers
as
	select Players.Id, Players.Name, Classes.Name as Class
	from Players
	join Classes on Players.ClassId = Classes.Id