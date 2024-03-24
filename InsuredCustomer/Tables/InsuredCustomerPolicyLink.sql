CREATE TABLE [dbo].[InsuredCustomerPolicyLink]
(
	[PolicyLinkId] INT NOT NULL PRIMARY KEY IDENTITY,
	[InsuredCustomerId] INT NOT NULL,
	[PolicyDetailsId] INT NOT NULL
	FOREIGN KEY([InsuredCustomerId]) REFERENCES InsuredCustomer(InsuredCustomerId)
	FOREIGN KEY([PolicyDetailsId]) REFERENCES PolicyDetails(PolicyDetailsId)
)
