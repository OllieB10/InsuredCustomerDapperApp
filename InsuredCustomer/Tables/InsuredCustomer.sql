CREATE TABLE [dbo].[InsuredCustomer]
(
	[InsuredCustomerId] INT NOT NULL PRIMARY KEY IDENTITY,
	[FirstName] VARCHAR(100) NULL,
	[LastName] VARCHAR(100) NULL,
	[TitleId] Int NULL,
	Sex VARCHAR(100) NULL,
	DateOfBirth Date NULL,
	Email VARCHAR(100) NULL,
	CONSTRAINT FK_TitleId FOREIGN KEY(TitleId) REFERENCES Title(TitleId)
)
