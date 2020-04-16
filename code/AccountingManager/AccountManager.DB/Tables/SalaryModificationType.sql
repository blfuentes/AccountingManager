CREATE TABLE [dbo].[SalaryModificationType]
(
    [SalaryModificationTypeID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(255) NOT NULL, 
    [DefaultValue] MONEY NOT NULL
)
