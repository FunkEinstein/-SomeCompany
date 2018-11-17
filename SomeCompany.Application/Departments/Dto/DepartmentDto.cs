using SomeCompany.Domain.Entities;

namespace SomeCompany.Application.Departments.Dto
{
    public class DepartmentDto
    {
        public int Id { get; set; }
        public string DepartmentName { get; set; }

        // ReSharper disable once UnusedMember.Global
        // for json serializer purposes
        public DepartmentDto()
        { }

        public DepartmentDto(int id, string departmentName)
        {
            Id = id;
            DepartmentName = departmentName;
        }

        public DepartmentDto(Department department)
            : this(department.Id, department.DepartmentName)
        { }
    }
}
