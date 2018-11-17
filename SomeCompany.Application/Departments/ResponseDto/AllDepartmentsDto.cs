using System.Collections.Generic;

namespace SomeCompany.Application.Departments.ResponseDto
{
    public class AllDepartmentsDto
    {
        public ICollection<DepartmentInfoDto> Departments { get; set; }

        public AllDepartmentsDto(ICollection<DepartmentInfoDto> departments)
        {
            Departments = departments;
        }
    }
}
