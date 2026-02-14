use EHealth

 Insert into [Hospitals]([Name]
      ,[Address]
      ,[PhoneNumber]
      ,[Email])
values 
('AZ Herentals', 'Kerkstraat 4', '032555555','azherentals@test.be') ,
('AZ Antwerpen', 'Grotebaan 11', '032544555','azantwerpen@test.be') ,
('UZ Leuven', 'Hoofdstraat 55', '0325123333','azleuven@test.be') 

Insert into [Doctors](
  [MedicalTitle],[SpecializationId],[LicenseNumber],[LicenseValidUntil],[PatientSurgeryId] ,[LastName] ,[FirstName],[MiddleName] ,[DateOfBirth]
      ,[Gender] ,[Address],[PhoneNumber],[Email] ,[FirstLanguageID] ,[Photo] ,[CreatedAt],[CreatedBy],[Position] ,[HospitalId] ,[DepartmentId]
      ,[InServiceDate] ,[OutServiceDate] ,[hospitalDepartmentId] ,[Salery]
  )
  values
         (
         1,1,'L4854484','2035-06-01  10:00:00',null,'Verbinnen','Peter',null,'1999-06-01  10:00:00',
         1,'Molenstraat 12', '032454545','peter@test.be',1,null,'2023-06-01  10:00:00',1,'doctor',1,1,
         '2020-06-01  10:00:00','2020-06-01  10:00:00',null,null
         ),
         (
         1,1,'L4859997','2035-02-01  10:00:00',null,'Janssens','Marc',null,'1998-07-01  10:00:00',
         1,'Eigennaarstraat 45', '032988877','marc@test.be',1,null,'2021-06-12  10:00:00',1,'doctor',1,1,
         '2020-08-01  10:00:00','2021-06-01  10:00:00',null,null
         ),
         (
         1,1,'L4857888','2032-01-01  10:00:00',null,'Peeters','Ludo',null,'1992-05-11  10:00:00',
         1,'Kleinhoef 78', '032988877','ludo@test.be',1,null,'2021-06-12  10:00:00',1,'doctor',1,1,
         '2020-05-01  10:00:00','2021-01-01  10:00:00',null,null
         )

insert into patients(
       [InsuranceNumber],[InsuranceProvider],[InsuranceExpiryDate] ,[IsMobile] ,[EmergencyContactName] ,[EmergencyContactPhoneNumber] ,[EmergencyContactDescription]
      ,[BloodTypeId],[LastName],[FirstName],[MiddleName],[DateOfBirth],[Gender],[Address],[PhoneNumber],[Email] ,[FirstLanguageID] ,[Photo]
      ,[CreatedAt],[CreatedBy],[MorePersonPatientRoomId])
values
      ('a115491','Alexia','2024-06-01  10:00:00',1,null,null,null,1,'Gevers','Inne','Frans','1995-06-01  10:00:00',2,'Turnhout','122555','Inne@test.be',1,null,'2020-04-01  10:00:00',1,null),
      ('a145549','Alexia','2023-06-09  10:00:00',1,null,null,null,1,'Peeters','Els','Jan','1994-04-01  10:00:00',2,'Antwerpen','122555','Els@test.be',1,null,'2026-06-01  10:00:00',1,null),
      ('a122222','Alexia','2020-07-01  10:00:00',1,null,null,null,1,'Janssens','Jan','Maria','1990-06-05  10:00:00',1,'Geel','122555','Jan@test.be',1,null,'2026-06-01  10:00:00',1,null),
      ('a777777','Alexia','2024-06-04  10:00:00',1,null,null,null,1,'Versmissen','Wim',null,'1991-01-01  10:00:00',1,'Antwerpen','122555','Wim@test.be',1,null,'2026-06-01  10:00:00',1,null)

Insert into [DoctorAppointments]([PatientId],[DoctorId],[AppointmentDate] ,[ReasonForVisit] ,[Notes] ,[Status],[DegreeOfUrgency] ,[CreatedBy] ,[CreatedAt] ,[AppointmentPlaceId])
values 
(3,12,'2026-06-01  10:00:00','check up',null,1,1,1,getdate(),1),
(3,13,'2026-07-03  10:00:00','check up',null,1,1,1,getdate(),1)