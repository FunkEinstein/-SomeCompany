CREATE TABLE [dbo].[Employees] (
    [Id]           INT            IDENTITY (1, 1) NOT NULL,
    [Name]         TEXT           NOT NULL,
    [Email]        NVARCHAR (450) NOT NULL,
    [Salary]       INT            NOT NULL,
    [Hired]        DATE           NOT NULL,
    [DepartmentId] INT            NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([DepartmentId]) REFERENCES [dbo].[Departments] ([Id]),
    UNIQUE NONCLUSTERED ([Email] ASC)
);

