select Person.Id, Person.FName, Person.LName, Person.Dob, Genders.name as Gender, OccupationTypes.name as Occupation, Company.Name as CompanyName, CTypes.Name as CType
from Person
inner join Company on Person.CompanyId = Company.Id
inner join OccupationTypes on Person.OccupationId = OccupationTypes.Id
inner join Genders on Person.Gender = Genders.Id
inner join CTypes on Company.CType = CTypes.Id