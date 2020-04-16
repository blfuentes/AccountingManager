CREATE TABLE [dbo].[ExpenseType]
(
    [ExpenseTypeID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(255) NOT NULL, 
    [ExpenseFamilyID] INT NOT NULL, 
    CONSTRAINT [FK_ExpenseType_ToExpenseFamily] FOREIGN KEY ([ExpenseFamilyID]) REFERENCES [ExpenseFamily]([ExpenseFamilyID])
)
