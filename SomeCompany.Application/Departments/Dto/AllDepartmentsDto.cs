using System.Collections.Generic;

namespace SomeCompany.Application.Departments.Dto
{
    public class AllDepartmentsDto
    {
        public ICollection<DepartmentDto> Departments { get; set; }

        public AllDepartmentsDto(ICollection<DepartmentDto> departments)
        {
            Departments = departments;
        }
    }
}
