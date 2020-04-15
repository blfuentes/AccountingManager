CREATE TABLE [dbo].[Expense]
(
    [ExpenseID] INT NOT NULL PRIMARY KEY, 
    [Amount] MONEY NOT NULL, 
    [ExpenseTypeID] INT NOT NULL, 
    CONSTRAINT [FK_Expense_ToExpenseType] FOREIGN KEY ([ExpenseTypeID]) REFERENCES [ExpenseType]([ExpenseTypeID])
)
