CREATE TABLE [dbo].[SalaryModification]
(
    [SalaryModificationID] INT NOT NULL PRIMARY KEY, 
    [Amount] MONEY NOT NULL, 
    [SalaryID] INT NOT NULL, 
    [SalaryModificationTypeID] INT NOT NULL, 
    CONSTRAINT [FK_SalaryModification_ToSalary] FOREIGN KEY ([SalaryID]) REFERENCES [Salary]([SalaryID]), 
    CONSTRAINT [FK_SalaryModification_ToSalaryModificationType] FOREIGN KEY ([SalaryModificationTypeID]) REFERENCES [SalaryModificationType]([SalaryModificationTypeID])
)
