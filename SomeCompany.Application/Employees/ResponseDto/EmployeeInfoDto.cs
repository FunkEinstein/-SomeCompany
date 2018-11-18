using System;

namespace SomeCompany.Application.Employees.ResponseDto
{
    public class EmployeeInfoDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Salary { get; set; }
        public DateTime Hired { get; set; }
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
    }
}
