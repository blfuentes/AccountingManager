CREATE TABLE [dbo].[Payment]
(
    [PaymentID] INT NOT NULL PRIMARY KEY, 
    [Amount] MONEY NOT NULL, 
    [ValidTo] DATETIME2 NULL
)
