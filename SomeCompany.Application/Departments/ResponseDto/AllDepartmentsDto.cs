using System.Collections.Generic;

namespace SomeCompany.Application.Departments.ResponseDto
{
    public class AllDepartmentsDto
    {
        public int AllDepartments { get; set; }
        public ICollection<DepartmentInfoDto> Departments { get; set; }

        public AllDepartmentsDto(ICollection<DepartmentInfoDto> departments, int allDepartments)
        {
            Departments = departments;
            AllDepartments = allDepartments;
        }
    }
}
