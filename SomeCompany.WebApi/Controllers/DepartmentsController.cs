using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SomeCompany.Application.Departments.Add;
using SomeCompany.Application.Departments.Delete;
using SomeCompany.Application.Departments.Dto;
using SomeCompany.Application.Departments.Get;
using SomeCompany.Application.Departments.Update;

namespace SomeCompany.WebApi.Controllers
{
    public class DepartmentsController : ApiControllerBase
    {
        #region Get

        //GET /api/departments/get/{id}
        [HttpGet("get/{id:int:min(1)}")]
        [ProducesResponseType(typeof(DepartmentDto), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetDepartment(int id)
        {
            var getDepartmentQuery = new GetDepartmentQuery(id);
            return Ok(await Mediator.Send(getDepartmentQuery));
        }

        //GET /api/departments/all
        [HttpGet("all")]
        [ProducesResponseType(typeof(AllDepartmentsDto), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAllDepartments()
        {
            return Ok(await Mediator.Send(new GetAllDepartmentsQuery()));
        }

        #endregion

        #region Add

        //POST /api/departments/add
        [HttpPost("add")]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> AddDepartment([FromBody] DepartmentDto departmentDto)
        {
            var addDepartmentCommand = new AddDepartmentCommand(departmentDto);
            return Ok(await Mediator.Send(addDepartmentCommand));
        }

        #endregion

        #region Update

        //PUT /api/departments/update
        [HttpPut("update")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateDepartment([FromBody] DepartmentDto departmentDto)
        {
            var updateDepartmentCommand = new UpdateDepartmentCommand(departmentDto);
            return Ok(await Mediator.Send(updateDepartmentCommand));
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
