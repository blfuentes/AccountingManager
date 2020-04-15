CREATE TABLE [dbo].[ForecastDetail_Expense]
(
    [ForecastDetailID] INT NOT NULL , 
    [ExpenseID] INT NOT NULL, 
    PRIMARY KEY ([ExpenseID], [ForecastDetailID]), 
    CONSTRAINT [FK_ForecastDetail_Expense_ToForecastDetail] FOREIGN KEY ([ForecastDetailID]) REFERENCES [ForecastDetail]([ForecastDetailID]), 
    CONSTRAINT [FK_ForecastDetail_Expense_ToExpense] FOREIGN KEY ([ExpenseID]) REFERENCES [Expense]([ExpenseID])
)
