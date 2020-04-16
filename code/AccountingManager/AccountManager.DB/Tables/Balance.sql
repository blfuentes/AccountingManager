CREATE TABLE [dbo].[Balance]
(
    [BalanceID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [InitialAmount] MONEY NOT NULL, 
    [FinalAmount] MONEY NOT NULL, 
    [Variation] AS ([FinalAmount] - [InitialAmount]) PERSISTED, 
    [PercentVariation] FLOAT NOT NULL, 
    [Date] DATETIME2 NOT NULL, 
    [DateClosed] DATETIME2 NULL
)
