using SomeCompany.Domain.Entities;

namespace SomeCompany.Application.Employees.ResponseDto
{
    public static class Extensions
    {
        public static EmployeeInfoDto ToEmployeeInfoDto(this Employee employee)
        {
            var employeeInfo = new EmployeeInfoDto
            {
                Id = employee.Id,
                Name = employee.Name,
                Email = employee.Email,
                Hired = employee.Hired,
                Salary = employee.Salary,
                DepartmentId = employee.DepartmentId,
                DepartmentName = employee.Department.DepartmentName
            };

            return employeeInfo;
        }
    }
}
