using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SomeCompany.Application.Employees.Get;

namespace SomeCompany.WebApi.Controllers
{
    public class TestController : ApiControllerBase
    {
        //GET /api/test
        [HttpGet]
        public async Task<IActionResult> Test()
        {
            var getEmployeeQuery = new GetEmployeeQuery(2);
            return Ok(await Mediator.Send(getEmployeeQuery));
        }
    }
}
