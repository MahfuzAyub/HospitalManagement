
use HospitalManagementDb
GO
Create Table Designation
(
	DesigId int primary key,
	Designation varchar(50) not null
)
go
Create Table Speciality
(
	SpecialitytId int primary key,
	Speciality varchar(50) not null
)
go
Create Table Gender
(
	GenderId int primary key,
	Gender varchar(50) not null
)
go
create table doctor
(
DoctorId int primary key identity,
DoctorName varchar(50) not null,
DesigNationId int foreign key references Designation(DesigId) not null,
SpecialitytId int foreign key references Speciality(SpecialitytId) not null,
MobileNo varchar(11) not null,
[Address] varchar(100) not null,
Email Varchar(50),
GenderId  int foreign key references Gender(GenderId),
JoinDate date null,
NIDno varchar(55)
)
GO
insert into doctor values('emart',1,1,'3513132','narail','dfd@gmil.com',1,'1/1/2000','121213223')
go
create proc spShowDoctorsInfo
as
select d.DoctorId,d.DoctorName,dg.Designation,sp.Speciality,d.MobileNo,d.Address,d.Email,g.Gender,d.JoinDate,d.NIDno from doctor d inner join 
Designation dg on d.DesigNationId=dg.DesigId join
gender g on d.GenderId=g.GenderId join
Speciality sp on d.SpecialitytId=sp.SpecialitytId
go
select * from doctor
go
select d.DoctorId,d.DoctorName,dg.Designation,sp.Speciality,d.MobileNo,d.Address,d.Email,g.Gender,d.JoinDate,d.NIDno from doctor d inner join 
Designation dg on d.DesigNationId=dg.DesigId join
gender g on d.GenderId=g.GenderId join
Speciality sp on d.SpecialitytId=sp.SpecialitytId where d.DoctorId=1
go
select * from doctor

  Create Table employee
  (
  Id int identity  primary key  ,
  name varchar(50) not null,
  [Password] varchar(50) not null

  create table Patient
  (
	PatientId int primary key Identity,
	PatientName varchar(30) not null,
	GenderId  int foreign key references Gender(GenderId),
	DateOfBirth date,
	Age int,
	Address varchar(100) null,
	Mobile varchar(13) null,
	Disease varchar(50) null,
	--SpecialitytId int foreign key references Speciality(SpecialitytId)  null,
	--DoctorId int foreign key references doctor(doctorId), 
	AppointmentDate date,
	picture image null
  )
  GO

  Select PatientId,PatientName from patient where PatientId=1


  insert into patient(PatientName,GenderId,RegistratioDate,age,Address,Mobile,Disease,picture,Email,NID) values('jjj',1,'1/1/2000',22,'dhaka','01555','eye','','.com','nid')
  go
  select * from patient
  update patient set PatientName='name',GenderId=2,RegistratioDate='1/1/2000',age=20,Address='dha',Mobile='0111',Disease='dss',email='dfd@',nid='nid' where PatientId =1

  delete Patient where PatientId=1

  Create table Appointment
  (
		appointmetnId int primary key identity(1000,1),
		doctorId int foreign key references doctor(doctorId),
		patientId int foreign key references patient(PatientId),
		SpecialitytId int foreign key references Speciality(SpecialitytId)  null,
		appointmentDate date 
  )
  go


  insert into Appointment values (1,1,1,'1/1/2000')
  select * from Appointment

 create proc spAppointmentInfo
 as
 begin 
	  select a.appointmetnId,p.PatientName,d.DoctorName,s.Speciality,a.appointmentDate from Appointment a join 
	  doctor d on a.doctorid=d.DoctorId join 
	  patient p on p.PatientId=a.patientId join 
	  Speciality s on s.SpecialitytId = a.SpecialitytId
 end

Create table bill
(
PatientId varchar(30) references patient(PatientId),
PatientName varchar(30) not null,
RoomNo varchar(30) not null,
DoctorVisitCharge varchar(30) not null,
Drugs varchar(30) not null,
RoomRent varchar(30) not null,
EquipmentCharges varchar(30) not null,
Others varchar(30),
BId varchar(30) not null,
Total varchar(30) 
)
Go

select * from doctor where SpecialitytId =4
select * from users


begin try
	insert into Users values ('7',2)
end try
begin catch
	select ERROR_NUMBER()
end catch
select * from Users where userName='1' and password=1

select PatientId,PatientName,Mobile,NID from Patient where PatientName LIKE '%apple%' and Mobile=''