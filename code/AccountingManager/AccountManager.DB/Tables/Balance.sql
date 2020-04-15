CREATE TABLE [dbo].[Balance]
(
    [BalanceID] INT NOT NULL PRIMARY KEY, 
    [InitialAmount] MONEY NOT NULL, 
    [FinalAmount] MONEY NOT NULL, 
    [Variation] MONEY NOT NULL, 
    [PercentVariation] FLOAT NOT NULL, 
    [Date] DATETIME2 NOT NULL, 
    [DateClosed] DATETIME2 NULL
)
