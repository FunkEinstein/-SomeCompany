using System;

namespace SomeCompany.Domain.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Salary { get; set; }
        public DateTime Hired { get; set; }
        public int DepartmentId { get; set; }

        public Department Department { get; set; }
    }
}
