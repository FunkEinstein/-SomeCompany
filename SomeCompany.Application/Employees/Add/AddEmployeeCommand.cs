using System;
using MediatR;

namespace SomeCompany.Application.Employees.Add
{
    public class AddEmployeeCommand : IRequest<int>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public int Salary { get; set; }
        public DateTime Hired { get; set; }
        public int DepartmentId { get; set; }
    }
}
