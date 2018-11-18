using System.Collections.Generic;

namespace SomeCompany.Application.Employees.ResponseDto
{
    public class AllEmployeesDto
    {
        public ICollection<EmployeeInfoDto> Employees { get; set; }

        public AllEmployeesDto(ICollection<EmployeeInfoDto> employees)
        {
            Employees = employees;
        }
    }
}
