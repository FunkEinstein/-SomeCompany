using System.Collections.Generic;

namespace SomeCompany.Application.Departments.ResponseDto
{
    public class AllDepartmentsDto
    {
        public int AllEmployees { get; set; }
        public ICollection<DepartmentInfoDto> Departments { get; set; }

        public AllDepartmentsDto(ICollection<DepartmentInfoDto> departments, int allEmployees)
        {
            Departments = departments;
            AllEmployees = allEmployees;
        }
    }
}
