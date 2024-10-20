using ASDP.FinalProject.UseCases.Employees.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ASDP.FinalProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizeController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IConfiguration _configuration;

        public AuthorizeController(IMediator mediator, IConfiguration configuration)
        {
            _mediator = mediator;
            _configuration = configuration;
        }

        /// <summary>
        /// полчить информацию о сотруднике. если null - значит не зарегистрирован
        /// </summary>
        /// <param name="iin"></param>
        /// <returns></returns>
        [HttpGet("getEmployeeByIin")]
        public async Task<IActionResult> GetEmployeeByIin(string iin)
        {
            return Ok( await _mediator.Send(new GetEmployeeByIinQuery { Iin = iin }));
        }

    }
}
