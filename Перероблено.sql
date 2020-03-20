USE master;
GO
		IF DB_ID('Airoport2') IS NOT NULL
		BEGIN
			DROP DATABASE MyAiroport2;
		END;
		GO
iF DB_ID('MiyAiroport1') IS NULL
BEGIN
	CREATE DATABASE Airoport2
		CONTAINMENT=NONE
		ON PRIMARY
	(NAME = N'Airoport2', FILENAME=N'C:\PK4\Airoport2.mdf', SIZE=6096KB, MAXSIZE = UNLIMITED, FILEGROWTH=1024KB)
		LOG ON
	(NAME = N'Airoport_log', FILENAME=N'C:\PK4\Airoport_log.ldf', SIZE=1024KB, MAXSIZE = 2048GB, FILEGROWTH=10%)
		COLLATE Ukrainian_100_CI_AS;
END;
GO

USE Airoport2;
GO

IF NOT EXISTS (SELECT 1 FROM sys.TABLES WHERE Name=N'Aviakompania' And Type=N'U')
BEGIN
CREATE TABLE [dbo].[Aviakompania] (
				[Aviakompania_ID] int identity (1,1) NOT NULL,
				[Nazva] NVARCHAR (100) NOT NULL,
				[NomerTelefony] NVARCHAR (20) NOT NULL,
				[E-Mail] NVARCHAR (40) NOT NULL,
			    [Litak_ID] INT  NOT NULL

				CONSTRAINT PK_Aviakompania PRIMARY KEY CLUSTERED (Aviakompania_ID)

				
)
END;

IF NOT EXISTS (SELECT 1 FROM sys.TABLES WHERE Name=N'Litak' And Type=N'U')
BEGIN
	CREATE TABLE [dbo].[Litak](
			[Litak_ID] INT  identity (1,1) NOT NULL,
			[Nazva]NVARCHAR (100) NOT NULL,
			[Aviakompania_ID] int NOT NULL,
			[Model] nvarchar (20)  not null,
			[KilkistMisc] NVARCHAR (100) NOT NULL,
			CONSTRAINT PK_Litak PRIMARY KEY CLUSTERED (Litak_ID),
			CONSTRAINT FK_Litak_Aviakompania FOREIGN KEY (Aviakompania_ID) REFERENCES dbo.Aviakompania (Aviakompania_ID)
			
			
	)
END;




GO

IF NOT EXISTS (SELECT 1 FROM sys.TABLES WHERE Name=N'Marshrut' And Type=N'U')
BEGIN
CREATE TABLE [dbo].[Marshrut] (
				[MarshrutID] INT IDENTITY (1,1) NOT NULL,
				[Kudy] NVARCHAR (20) NOT NULL,
				[Opys] NVARCHAR (20) NOT NULL,
				[Litak_ID] int not null

				CONSTRAINT PK_Marshrut PRIMARY KEY CLUSTERED (MarshrutID)
				CONSTRAINT FK_Marshrut_Litak FOREIGN KEY (Litak_ID) REFERENCES dbo.Litak (Litak_ID)
)
END;
GO

IF NOT EXISTS (SELECT 1 FROM sys.TABLES WHERE Name=N'Pasagir' And Type=N'U')
BEGIN
	CREATE TABLE[dbo].[Pasagir](
			[ID_Pasagir] INT identity (1,1) NOT NULL,
			[Surname] NVARCHAR (100) NOT NULL,
			[Name] NVARCHAR (100) NOT NULL,
			[NomerTelefony] NVARCHAR (50) NOT NULL,
			[Pasport] NVARCHAR (100) NOT NULL,
			[TicketsID] INT NOT NULL,
			[Litak_ID] int NOT NULL
			CONSTRAINT PK_Pasagir PRIMARY KEY CLUSTERED (ID_Pasagir),
			CONSTRAINT FK_Pasagir_Litak FOREIGN KEY (Litak_ID) REFERENCES dbo.Litak (Litak_ID)
			
	)
END;


IF NOT EXISTS (SELECT 1 FROM sys.TABLES WHERE Name=N'Tickets' And Type=N'U')
BEGIN
CREATE TABLE [dbo].[Tickets] (
				[TicketsID] INT IDENTITY (1,1) NOT NULL,
				[ReysID] int NOT NULL,
				[Cina] int NOT NULL,
				[DataVidpravlennya] date NOT NULL,
				[ID_Pasagir] int not null
				CONSTRAINT PK_Tickets PRIMARY KEY CLUSTERED (TicketsID),
				CONSTRAINT FK_Tickets_ID_ID_Pasagir FOREIGN KEY (ID_Pasagir) REFERENCES dbo.Pasagir (ID_Pasagir)

)
END;
GO
IF NOT EXISTS (SELECT 1 FROM sys.TABLES WHERE Name=N'Reys' And Type=N'U')
BEGIN
CREATE TABLE [dbo].[Reys] (
				[ReysID] INT IDENTITY (1,1) NOT NULL,
				[Litak_ID] int NOT NULL,
				[Data] Date NOT NULL,
				[ChasVidpravlennya] datetime  NOT NULL,
				[MarshrutID] INT NOT NULL,
				[ChasPrybuttya] datetime  NOT NULL,
				[TicketsID] int NOT NULL
				CONSTRAINT PK_Reys PRIMARY KEY CLUSTERED (ReysID),
				CONSTRAINT FK_Reys_Litak FOREIGN KEY (Litak_ID) REFERENCES dbo.Litak (Litak_ID),
				CONSTRAINT FK_Reys_Marshrut FOREIGN KEY (MarshrutID) REFERENCES dbo.Marshrut (MarshrutID),
				CONSTRAINT FK_Reys_Tickets FOREIGN KEY (TicketsID) REFERENCES dbo.Tickets (TicketsID)
)
END;
GO



IF NOT EXISTS (SELECT 1 FROM sys.TABLES WHERE Name=N'Posada' And Type=N'U')
BEGIN
CREATE TABLE [dbo].[Posada] (
				[Posada_ID] INT IDENTITY (1,1) NOT NULL,
				[NazvaPosady] NVARCHAR (20) Not NULL
				CONSTRAINT PK_Posada PRIMARY KEY CLUSTERED (Posada_ID)
				

)
END;
GO

IF NOT EXISTS (SELECT 1 FROM sys.TABLES WHERE Name=N'Personal' And Type=N'U')
BEGIN
CREATE TABLE [dbo].[Personal] (
				[Personal_ID] INT IDENTITY (1,1) NOT NULL,
				[Surname] NVARCHAR (20) NOT NULL,
				[Posada_ID] INT NOT NULL,
				[KilkistPolotiv] INT NOT NULL,
				[Vik] int not null
				CONSTRAINT PK_Personal PRIMARY KEY CLUSTERED (Personal_ID),
				CONSTRAINT FK_Personal_ID_Posada_ID FOREIGN KEY (Posada_ID) REFERENCES dbo.Posada (Posada_ID)

				
)
END;
GO


IF NOT EXISTS (SELECT 1 FROM sys.TABLES WHERE Name=N'Obsl' And Type=N'U')
BEGIN
CREATE TABLE [dbo].[Obsl] (
				[Obsl_ID] int identity (1,1) not null,
				[Litak_ID] int not null,
				[date] datetime Not NULL,
				[Stan] NVARCHAR (50) NOT NULL,
				[Personal_ID] INT  NOT NULL
				CONSTRAINT PK_Obsl PRIMARY KEY CLUSTERED (Obsl_ID),
				CONSTRAINT FK_Obsl_ID_Litak_ID FOREIGN KEY (Litak_ID) REFERENCES dbo.Litak (Litak_ID),
				CONSTRAINT FK_Obsl_ID_Personal_ID FOREIGN KEY (Personal_ID) REFERENCES dbo.Personal (Personal_ID)
				

				
)
END;
GO




