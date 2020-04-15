CREATE TABLE [dbo].[ExpenseModification]
(
    [ExpenseModificationID] INT NOT NULL PRIMARY KEY, 
    [Amount] MONEY NOT NULL, 
    [ValidFrom] DATETIME2 NOT NULL, 
    [ExpenseID] INT NOT NULL, 
    CONSTRAINT [FK_ExpenseModification_ToExpense] FOREIGN KEY ([ExpenseID]) REFERENCES [Expense]([ExpenseID])
)
