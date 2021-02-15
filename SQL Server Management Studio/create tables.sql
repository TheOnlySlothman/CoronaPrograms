drop table Items
drop table ITypes
drop table Players
drop table Classes
drop table Person
drop table Company
drop table OccupationTypes
drop table Genders
drop table CTypes
 
create table CTypes (
	Id int not null primary key identity(1,1),
	Name varchar(15)
	)

create table Genders (
	Id bit not null primary key,
	Name char(1)
	)

create table OccupationTypes (
	Id int not null primary key identity(1,1),
	Name varchar(15)
	)

create table Company (
	Id int not null primary key identity(1,1),
	Name varchar(50),
	CType int foreign key references CTypes(Id)
	)

create table Person (
	Id int not null primary key identity(1,1),
	FName varchar(30),
	LName varchar(30),
	Dob date,
	Gender bit foreign key references Genders(Id),
	OccupationId int foreign key references OccupationTypes(Id),
	CompanyId int foreign key references Company(Id)
	)

create table Classes (
	Id int not null primary key,
	Name varchar(15)
	)

create table Players (
	Id int not null primary key,
	Name varchar(15),
	ClassId int foreign key references Classes(Id)
	)

create table ITypes (
	Id int not null primary key,
	Name varchar(15)
	)

create  table Items (
	Id int not null primary key identity(1,1),
	Name varchar(15),
	TypeId int foreign key references ITypes(Id),
	Weight Decimal
	)