using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SomeCompany.Application.Departments.Add;
using SomeCompany.Application.Departments.Delete;
using SomeCompany.Application.Departments.Get;
using SomeCompany.Application.Departments.ResponseDto;
using SomeCompany.Application.Departments.Update;

namespace SomeCompany.WebApi.Controllers
{
    public class DepartmentsController : ApiControllerBase
    {
        #region Get

        //GET /api/departments/get/{id}
        [HttpGet("get/{id:int:min(1)}")]
        [ProducesResponseType(typeof(DepartmentInfoDto), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetDepartment(int id)
        {
            var getDepartmentQuery = new GetDepartmentQuery(id);
            return Ok(await Mediator.Send(getDepartmentQuery));
        }

        //GET /api/departments/all
        [HttpGet("all")]
        [ProducesResponseType(typeof(AllDepartmentsDto), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAllDepartments([FromBody] GetAllDepartmentsQuery query)
        {
            return Ok(await Mediator.Send(query));
        }

        #endregion

        #region Add

        //POST /api/departments/add
        [HttpPost("add")]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> AddDepartment([FromBody] AddDepartmentCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        #endregion

        #region Update

        //PUT /api/departments/update
        [HttpPut("update")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateDepartment([FromBody] UpdateDepartmentCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        #endregion

        #region Delete

        //DELETE /api/departments/delete/{id}
        [HttpDelete("delete/{id:int:min(1)}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteDepartment(int id)
        {
            var deleteDepartmentCommand = new DeleteDepartmentCommand(id);
            return Ok(await Mediator.Send(deleteDepartmentCommand));
        }

        #endregion
    }
}
