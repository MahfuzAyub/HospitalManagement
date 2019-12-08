

Create table tblGroup
(
	GroupId int primary key identity,
	GroupName varchar(50) not null
)
go
Create table tblTest
(
	testId int primary key identity,
	TestName varchar(50) not null,
	price money,
	GroupId int references tblGroup(GroupId)
)
go

select * from tblGroup
select * from tblTest