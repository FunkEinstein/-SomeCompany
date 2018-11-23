CREATE TABLE [dbo].[Departments] (
    [Id]             INT            IDENTITY (1, 1) NOT NULL,
    [DepartmentName] NVARCHAR (450) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    UNIQUE NONCLUSTERED ([DepartmentName] ASC)
);

