CREATE TABLE [dbo].[ForecastDetail]
(
    [ForecastDetailID] INT NOT NULL PRIMARY KEY, 
    [Month] INT NOT NULL, 
    [InitialBalance] MONEY NOT NULL, 
    [ExtraExpenses] MONEY NULL, 
    [CreditAmount] MONEY NOT NULL, 
    [CarAmount] MONEY NULL, 
    [FlightAmount] MONEY NULL, 
    [Comments] NVARCHAR(255) NULL, 
    [Estimation] MONEY NOT NULL, 
    [BalanceEstimation] MONEY NOT NULL, 
    [Adjustment] MONEY NOT NULL, 
    [FinalAmount] MONEY NOT NULL, 
    [FinalBalance] MONEY NOT NULL, 
    [SavingsPercent] FLOAT NOT NULL, 
    [IsClosed] BIT NOT NULL, 
    [PaymentID] INT NOT NULL, 
    CONSTRAINT [FK_ForecastDetail_ToPayment] FOREIGN KEY ([PaymentID]) REFERENCES [Payment]([PaymentID])
)
