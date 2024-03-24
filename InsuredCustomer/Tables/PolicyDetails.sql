CREATE TABLE [dbo].[PolicyDetails]
(
	[PolicyDetailsId] INT NOT NULL PRIMARY KEY IDENTITY,
	[PolicyStartDate] DateTime NOT NULL,
	[PolicyEndDate] DateTime NOT NULL,
	[CancellationDate] DateTime NULL
)
