CREATE DATABASE VetSystem
GO
USE VetSystem
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE AnimalTypes (
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL
	CONSTRAINT [PK_AnimalTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) 
GO

INSERT INTO [dbo].AnimalTypes ([Name]) VALUES (N'Dog')
INSERT INTO [dbo].AnimalTypes ([Name]) VALUES (N'Cat')
INSERT INTO [dbo].AnimalTypes ([Name]) VALUES (N'Rabbit')

CREATE TABLE AnimalSubTypes (
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[ParentAnimal] [int] NOT NULL
	CONSTRAINT [PK_AnimalSubTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) 
GO

ALTER TABLE [dbo].AnimalSubTypes  WITH CHECK ADD  CONSTRAINT [FK_AnimalSubTypes_ParentAnimal] FOREIGN KEY([ParentAnimal])
REFERENCES [dbo].AnimalTypes ([Id])
GO
ALTER TABLE [dbo].AnimalSubTypes CHECK CONSTRAINT [FK_AnimalSubTypes_ParentAnimal]
GO

INSERT INTO [dbo].AnimalSubTypes ([Name], [ParentAnimal]) VALUES (N'Golden Retriever', 1)
INSERT INTO [dbo].AnimalSubTypes ([Name], [ParentAnimal]) VALUES (N'Labrador Retriever', 1)
INSERT INTO [dbo].AnimalSubTypes ([Name], [ParentAnimal]) VALUES (N'Pitbul', 1)
INSERT INTO [dbo].AnimalSubTypes ([Name], [ParentAnimal]) VALUES (N'Persian cat', 2)
INSERT INTO [dbo].AnimalSubTypes ([Name], [ParentAnimal]) VALUES (N'Siamese cat', 2)
INSERT INTO [dbo].AnimalSubTypes ([Name], [ParentAnimal]) VALUES (N'Russian blue', 2)
INSERT INTO [dbo].AnimalSubTypes ([Name], [ParentAnimal]) VALUES (N'American Fuzzy Lop', 3)
INSERT INTO [dbo].AnimalSubTypes ([Name], [ParentAnimal]) VALUES (N'Britannia Petite', 3)
INSERT INTO [dbo].AnimalSubTypes ([Name], [ParentAnimal]) VALUES (N'Dwarf Hotot', 3)

CREATE TABLE Owners (
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](80) NOT NULL,
	[Phone] [varchar](50) NOT NULL,
	[Email] [varchar](50) NOT NULL,
  [Password] [varchar](50) NOT NULL
	CONSTRAINT [PK_Owners] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) 
GO

INSERT INTO [dbo].Owners ([Name], [Phone], [Email], [Password]) VALUES (N'Zhivko Vasilev', N'+359899121343', N'jivko.vasilev@gmail.com', N'1234')
INSERT INTO [dbo].Owners ([Name], [Phone], [Email], [Password]) VALUES (N'Teodora Petrova', N'+359883558164', N'teodora.petrova21@gmail.com', N'1234')

CREATE TABLE Pets (
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](80) NOT NULL,
	[OwnerID] [INT] NOT NULL,
	[AnimalTypeID] [INT] NOT NULL,
	[AnimalSubTypeID] [INT] NOT NULL
	CONSTRAINT [PK_Pets] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) 
GO

ALTER TABLE [dbo].Pets  WITH CHECK ADD  CONSTRAINT [FK_Pets_Owner] FOREIGN KEY([OwnerID])
REFERENCES [dbo].Owners ([Id])
GO
ALTER TABLE [dbo].Pets CHECK CONSTRAINT [FK_Pets_Owner]
GO
ALTER TABLE [dbo].Pets  WITH CHECK ADD  CONSTRAINT [FK_Pets_AnimalType] FOREIGN KEY([AnimalTypeID])
REFERENCES [dbo].AnimalTypes ([Id])
GO
ALTER TABLE [dbo].Pets CHECK CONSTRAINT [FK_Pets_AnimalType]
GO
ALTER TABLE [dbo].Pets  WITH CHECK ADD  CONSTRAINT [FK_Pets_AnimalSubType] FOREIGN KEY([AnimalSubTypeID])
REFERENCES [dbo].AnimalSubTypes ([Id])
GO
ALTER TABLE [dbo].Pets CHECK CONSTRAINT [FK_Pets_AnimalSubType]
GO

INSERT INTO [dbo].Pets ([Name], [OwnerID], [AnimalTypeID], [AnimalSubTypeID]) VALUES (N'Murphy', 1, 1, 1)
INSERT INTO [dbo].Pets ([Name], [OwnerID], [AnimalTypeID], [AnimalSubTypeID]) VALUES (N'Terinka', 2, 1, 1)

CREATE TABLE Doctors (
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](80) NOT NULL,
	[Phone] [varchar](50) NOT NULL,
	[Email] [varchar](50) NOT NULL,
  [Password] [varchar](50) NOT NULL
	CONSTRAINT [PK_Doctors] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) 
GO

INSERT INTO [dbo].Doctors ([Name], [Phone], [Email], [Password]) VALUES (N'Dr. Borislav Georgiev', N'+359898361903', N'info@bluecrossbg.com', N'1234')
INSERT INTO [dbo].Doctors ([Name], [Phone], [Email], [Password]) VALUES (N'Dr. Miroslav Todorov', N'+359898361903', N'info@bluecrossbg.com', N'1234')
INSERT INTO [dbo].Doctors ([Name], [Phone], [Email], [Password]) VALUES (N'Dr. Ana Gospodinova', N'+359898361903', N'info@bluecrossbg.com', N'1234')
INSERT INTO [dbo].Doctors ([Name], [Phone], [Email], [Password]) VALUES (N'Dr. Ana Konzhilova', N'+359898361903', N'info@bluecrossbg.com', N'1234')
INSERT INTO [dbo].Doctors ([Name], [Phone], [Email], [Password]) VALUES (N'Dr. Vasya Serafimova', N'+359898361903', N'info@bluecrossbg.com', N'1234')
INSERT INTO [dbo].Doctors ([Name], [Phone], [Email], [Password]) VALUES (N'Dr. Andrey Ginchev', N'+359898361903', N'info@bluecrossbg.com', N'1234')

CREATE TABLE DoctorSpecialties (
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](80) NOT NULL,
	CONSTRAINT [PK_DoctorSpecialties] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) 
GO

INSERT INTO [dbo].DoctorSpecialties ([Name]) VALUES (N'Internal medicine')
INSERT INTO [dbo].DoctorSpecialties ([Name]) VALUES (N'Cardiology')
INSERT INTO [dbo].DoctorSpecialties ([Name]) VALUES (N'Surgery')
INSERT INTO [dbo].DoctorSpecialties ([Name]) VALUES (N'Orthopedics and traumatology')
INSERT INTO [dbo].DoctorSpecialties ([Name]) VALUES (N'Endoscopy')
INSERT INTO [dbo].DoctorSpecialties ([Name]) VALUES (N'Oncology')
INSERT INTO [dbo].DoctorSpecialties ([Name]) VALUES (N'Infectious diseases')
INSERT INTO [dbo].DoctorSpecialties ([Name]) VALUES (N'Obstetrics and Gynecology')
INSERT INTO [dbo].DoctorSpecialties ([Name]) VALUES (N'Dermatology')
INSERT INTO [dbo].DoctorSpecialties ([Name]) VALUES (N'Parasitology')
INSERT INTO [dbo].DoctorSpecialties ([Name]) VALUES (N'Dental care')
INSERT INTO [dbo].DoctorSpecialties ([Name]) VALUES (N'Imagining')
INSERT INTO [dbo].DoctorSpecialties ([Name]) VALUES (N'Clinical Laboratory')
INSERT INTO [dbo].DoctorSpecialties ([Name]) VALUES (N'Clinical Pathology')

CREATE TABLE DoctorSpecialtiesDoctors (
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DoctorID] [int] NOT NULL,
	[DoctorSpecialtiesID] [int] NOT NULL
	CONSTRAINT [PK_DoctorSpecialtiesDoctors] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) 
GO

ALTER TABLE [dbo].DoctorSpecialtiesDoctors  WITH CHECK ADD  CONSTRAINT [FK_DoctorSpecialtiesDoctors_DoctorID] FOREIGN KEY([DoctorID])
REFERENCES [dbo].Doctors ([Id])
GO
ALTER TABLE [dbo].DoctorSpecialtiesDoctors CHECK CONSTRAINT [FK_DoctorSpecialtiesDoctors_DoctorID]
GO

ALTER TABLE [dbo].DoctorSpecialtiesDoctors  WITH CHECK ADD  CONSTRAINT [FK_DoctorSpecialtiesDoctors_DoctorSpecialtiesID] FOREIGN KEY([DoctorSpecialtiesID])
REFERENCES [dbo].DoctorSpecialties ([Id])
GO
ALTER TABLE [dbo].DoctorSpecialtiesDoctors CHECK CONSTRAINT [FK_DoctorSpecialtiesDoctors_DoctorSpecialtiesID]
GO

INSERT INTO [dbo].DoctorSpecialtiesDoctors ([DoctorID],[DoctorSpecialtiesID]) VALUES (1, 4)
INSERT INTO [dbo].DoctorSpecialtiesDoctors ([DoctorID],[DoctorSpecialtiesID]) VALUES (1, 3)
INSERT INTO [dbo].DoctorSpecialtiesDoctors ([DoctorID],[DoctorSpecialtiesID]) VALUES (2, 1)
INSERT INTO [dbo].DoctorSpecialtiesDoctors ([DoctorID],[DoctorSpecialtiesID]) VALUES (2, 3)
INSERT INTO [dbo].DoctorSpecialtiesDoctors ([DoctorID],[DoctorSpecialtiesID]) VALUES (3, 1)
INSERT INTO [dbo].DoctorSpecialtiesDoctors ([DoctorID],[DoctorSpecialtiesID]) VALUES (3, 7)
INSERT INTO [dbo].DoctorSpecialtiesDoctors ([DoctorID],[DoctorSpecialtiesID]) VALUES (4, 9)
INSERT INTO [dbo].DoctorSpecialtiesDoctors ([DoctorID],[DoctorSpecialtiesID]) VALUES (4, 1)
INSERT INTO [dbo].DoctorSpecialtiesDoctors ([DoctorID],[DoctorSpecialtiesID]) VALUES (4, 3)
INSERT INTO [dbo].DoctorSpecialtiesDoctors ([DoctorID],[DoctorSpecialtiesID]) VALUES (5, 1)
INSERT INTO [dbo].DoctorSpecialtiesDoctors ([DoctorID],[DoctorSpecialtiesID]) VALUES (5, 13)
INSERT INTO [dbo].DoctorSpecialtiesDoctors ([DoctorID],[DoctorSpecialtiesID]) VALUES (6, 2)
INSERT INTO [dbo].DoctorSpecialtiesDoctors ([DoctorID],[DoctorSpecialtiesID]) VALUES (6, 3)


CREATE TABLE Statuses (
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](80) NOT NULL,
	CONSTRAINT [PK_Statuses] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) 
GO

INSERT INTO [dbo].Statuses ([Name]) VALUES (N'Waiting to be checked')
INSERT INTO [dbo].Statuses ([Name]) VALUES (N'Тhe patient is being reviewed right now')
INSERT INTO [dbo].Statuses ([Name]) VALUES (N'Тhe patient is currently in surgery')
INSERT INTO [dbo].Statuses ([Name]) VALUES (N'Тhe patient is in reanimation')
INSERT INTO [dbo].Statuses ([Name]) VALUES (N'Тhe patient is released from doctors care')
INSERT INTO [dbo].Statuses ([Name]) VALUES (N'Тhe patient is home and everything is OK')
INSERT INTO [dbo].Statuses ([Name]) VALUES (N'Case closed')

CREATE TABLE PetStatus (
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PetID] [int] NOT NULL,
	[StatusID] [int] NOT NULL,
	[DoctorID] [int] NOT NULL
	CONSTRAINT [PK_PetStatus] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) 
GO

ALTER TABLE [dbo].PetStatus  WITH CHECK ADD  CONSTRAINT [FK_PetStatus_PetID] FOREIGN KEY([PetID])
REFERENCES [dbo].Pets ([Id])
GO
ALTER TABLE [dbo].PetStatus CHECK CONSTRAINT [FK_PetStatus_PetID]
GO


ALTER TABLE [dbo].PetStatus  WITH CHECK ADD  CONSTRAINT [FK_PetStatus_StatusID] FOREIGN KEY([StatusID])
REFERENCES [dbo].Statuses ([Id])
GO
ALTER TABLE [dbo].PetStatus CHECK CONSTRAINT [FK_PetStatus_StatusID]
GO

ALTER TABLE [dbo].PetStatus  WITH CHECK ADD  CONSTRAINT [FK_PetStatus_DoctorID] FOREIGN KEY([DoctorID])
REFERENCES [dbo].Doctors ([Id])
GO
ALTER TABLE [dbo].PetStatus CHECK CONSTRAINT [FK_PetStatus_DoctorID]
GO