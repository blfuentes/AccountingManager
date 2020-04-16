CREATE TABLE [dbo].[Payment]
(
    [PaymentID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Amount] MONEY NOT NULL, 
    [ValidTo] DATETIME2 NULL
)
