using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SomeCompany.Application.Employees.Add;
using SomeCompany.Application.Employees.Delete;
using SomeCompany.Application.Employees.Get;
using SomeCompany.Application.Employees.ResponseDto;
using SomeCompany.Application.Employees.Update;

namespace SomeCompany.WebApi.Controllers
{
    public class EmployeesController : ApiControllerBase
    {
        #region Get

        //GET /api/employees/get/{id}
        [HttpGet("get/{id:int:min(1)}")]
        [ProducesResponseType(typeof(EmployeeInfoDto), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetEmployee(int id)
        {
            var getEmployeeQuery = new GetEmployeeQuery(id);
            return Ok(await Mediator.Send(getEmployeeQuery));
        }

        //POST /api/employees/all
        [HttpPost("all")]
        [ProducesResponseType(typeof(AllEmployeesDto), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAllEmployees([FromBody] GetAllEmployeesQuery query)
        {
            return Ok(await Mediator.Send(query));
        }

        #endregion

        #region Add

        //POST /api/employees/add
        [HttpPost("add")]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> AddEmployee([FromBody] AddEmployeeCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        #endregion

        #region Update

        //PUT /api/employees/update
        [HttpPut("update")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateEmployee([FromBody] UpdateEmployeeCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        #endregion

        #region Delete

        //DELETE /api/employees/delete/{id}
        [HttpDelete("delete/{id:int:min(1)}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var deleteEmployeeCommand = new DeleteEmployeeCommand(id);
            return Ok(await Mediator.Send(deleteEmployeeCommand));
        }

        #endregion
    }
}
