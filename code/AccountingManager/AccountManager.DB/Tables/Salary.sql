CREATE TABLE [dbo].[Salary]
(
    [SalaryID] INT NOT NULL PRIMARY KEY, 
    [BasePayment] MONEY NOT NULL, 
    [Date] DATETIME2 NOT NULL, 
    [PaymentDate] DATETIME2 NULL
)
