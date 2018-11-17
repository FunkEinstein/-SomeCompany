create table Departments (
	Id int primary key identity(1,1), 
	DepartmentName nvarchar(450) unique not null);

create table Employees (
	Id int primary key identity(1,1), 
	Name text not null, 
	Email nvarchar(450) unique not null, 
	Salary int not null, 
	Hired date not null,
	DepartmentId int not null foreign key references Departments(Id));