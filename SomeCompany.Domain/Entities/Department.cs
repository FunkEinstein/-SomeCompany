using System.Collections.Generic;

namespace SomeCompany.Domain.Entities
{
    public class Department
    {
        public Department()
        {
            Employee = new HashSet<Employee>();
        }

        public int Id { get; set; }
        public string DepartmentName { get; set; }

        public ICollection<Employee> Employee { get; set; }
    }
}
