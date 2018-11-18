using System.Collections.Generic;

namespace SomeCompany.Application.Employees.ResponseDto
{
    public class AllEmployeesDto
    {
        public int AllEmployees { get; set; }
        public ICollection<EmployeeInfoDto> Employees { get; set; }

        public AllEmployeesDto(ICollection<EmployeeInfoDto> employees, int allEmployees)
        {
            Employees = employees;
            AllEmployees = allEmployees;
        }
    }
}
