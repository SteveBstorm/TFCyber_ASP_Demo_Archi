﻿CREATE TABLE [dbo].[Person]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	Lastname VARCHAR(50) NOT NULL,
	Firstname VARCHAR(50) NOT NULL,
	PictureURL VARCHAR(MAX) NOT NULL
)
