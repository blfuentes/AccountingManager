CREATE TABLE [dbo].[Salary]
(
    [SalaryID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [BasePayment] MONEY NOT NULL, 
    [NetPayment] MONEY NULL,
    [Date] DATETIME2 NOT NULL, 
    [PaymentDate] DATETIME2 NULL
    
)
