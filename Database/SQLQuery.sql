use bigbang2

Create table Users 
(
UserId int identity(1,1) primary key, UserName nvarchar(max),Name nvarchar,
EmailId nvarchar(max),Password varbinary(max), HashKey varbinary(max) ,Role nvarchar(max),
)

Alter table users
alter column Name nvarchar(max)

Create table Patients
(
UserId int , PatientId int identity(1,1) primary key, patientName nvarchar(max),
Address nvarchar(max), mobilenum bigint , EmailId nvarchar(max)
Constraint FK_Patients_UserId Foreign Key (UserId) 
References Users(UserId)
)

Create table Doctors
(
UserId int , DoctorId int identity(1,1) primary key, Name nvarchar(max),Specialist nvarchar(max),
Address nvarchar(max), mobilenum bigint , EmailId nvarchar(max) ,Designation nvarchar(max), 
Constraint FK_Doctor_UserId Foreign Key (UserId) 
References Users(UserId)
)

ALTER TABLE Doctors
DROP CONSTRAINT  FK_Doctor_UserId;

Create table Appointments
(
AppointmentId int identity(1,1) primary key, PatientId int ,DoctorId int,
Date date, Time time, Purpose nvarchar(max),
Constraint FK_Appointment_PatientId Foreign Key (PatientId) 
References Patients(PatientId),
Constraint FK_Appointment_DoctorId Foreign Key (DoctorId) 
References Doctors(DoctorId)
)

alter table appointments 
add status nvarchar(max);


Alter table Appointments Add PatientAge int
Alter table Appointments Add PatientGender nvarchar(max)


Create Table Feedback 
(
FeedbackId int identity(1,1) primary key , AppointmentId int , Feedback nvarchar(max),
Constraint FK_Feedback_AppointmentId Foreign Key(AppointmentId)
References Appointments(AppointmentId)
)

select * from Users

select * from Doctors

select * from Appointments

select * from patients

select * from feedback

Alter table feedback drop column userId

alter table feedback drop constraint feedback_UserId

Alter table feedback add userId int constraint feedback_UserId foreign key(userId) references users(userId)

Alter table feedback add Email nvarchar(max)

Alter table Doctors Add ImageUrl nvarchar(max);

delete from users where role='admin'

CREATE TRIGGER InsertIntoDoctors
ON users
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;
    
    INSERT INTO doctors (UserId, Name, EmailId)
    SELECT userid, UserName, EmailId
    FROM inserted
    WHERE role = 'doctor';
END;



drop trigger InsertIntopatients

select doctorid from Doctors where "name" ='vishvak'

select * from Appointments where DoctorId=3 and status = 'booked'

select a.* from Appointments as a join Doctors as d on a.DoctorId = d.DoctorId 
where d.Name = 'Vishvak'  

select * from doctors

select * from users

select * from Patients

select * from Appointments

CREATE TRIGGER InsertIntoPatients
ON users
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;
    
    INSERT INTO Patients(userId, patientName, EmailId)
    SELECT userid, UserName, EmailId
    FROM inserted
    WHERE role = 'patient';
END;

