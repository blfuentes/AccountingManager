﻿CREATE TABLE [dbo].[Transaction]
(
    [TransactionID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Amount] MONEY NOT NULL, 
    [AnnotationDate] DATETIME2 NOT NULL, 
    [EffectiveDate] DATETIME2 NULL, 
    [OriginAccountID] INT NOT NULL, 
    [TargetAccountID] INT NULL, 
    [MovementID] INT NULL, 
    [TransactionTypeID] INT NOT NULL, 
    CONSTRAINT [FK_Transaction_ToMovement] FOREIGN KEY ([MovementID]) REFERENCES [Movement]([MovementID]), 
    CONSTRAINT [FK_Transaction_ToAccountOrigin] FOREIGN KEY ([OriginAccountID]) REFERENCES [Account]([AccountID]), 
    CONSTRAINT [FK_Transaction_ToAccountTarget] FOREIGN KEY ([TargetAccountID]) REFERENCES [Account]([AccountID]), 
    CONSTRAINT [FK_Transaction_ToTransactionType] FOREIGN KEY ([TransactionTypeID]) REFERENCES [TransactionType]([TransactionTypeID])
)
