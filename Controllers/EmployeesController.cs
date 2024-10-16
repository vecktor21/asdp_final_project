using ASDP.FinalProject.Constants;
using ASDP.FinalProject.DAL.Models;
using ASDP.FinalProject.UseCases.Employees.Commands;
using ASDP.FinalProject.UseCases.Employees.Dtos;
using ASDP.FinalProject.UseCases.Employees.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASDP.FinalProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EmployeesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// получить все права
        /// </summary>
        /// <returns></returns>
        [HttpGet("permissions")]
        [ProducesResponseType<List<Permission>>(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetPermissions()
        {
            return new JsonResult( await _mediator.Send(new GetPermissionsQuery()));
        }
        /// <summary>
        /// получить все должности
        /// </summary>
        /// <returns></returns>
        [HttpGet( "positions")]
        [ProducesResponseType<List<PositionDto>>(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetPositions()
        {
            return new JsonResult(await _mediator.Send(new GetPositionsQuery()));
        }
        /// <summary>
        /// полчить тимлидов
        /// </summary>
        /// <returns></returns>

        [HttpGet("teamleaders")]
        [ProducesResponseType<List<EmployeeDto>>(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetTeamleaders()
        {
            return new JsonResult(await _mediator.Send(new GetEmployeesQuery
            {
                Position = PositionCode.Teamlid
            }));
        }
        /// <summary>
        /// получить директоров
        /// </summary>
        /// <returns></returns>
        [HttpGet("directors")]
        [ProducesResponseType<List<EmployeeDto>>(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetDirectors()
        {
            return new JsonResult(await _mediator.Send(new GetEmployeesQuery
            {
                Position = PositionCode.Director
            }));
        }

        /// <summary>
        /// получить всех пользователей
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType<List<EmployeeDto>>(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllEmployees()
        {
            return new JsonResult(await _mediator.Send(new GetEmployeesQuery()));
        }

        /// <summary>
        /// регистрация сотрудника
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType<EmployeeDto>(StatusCodes.Status200OK)]
        public async Task<IActionResult> RegisterEmployee([FromBody]RegisterEmployeeRequest data)
        {
            var res = await _mediator.Send(data);
            return Ok(res);
        }
    }
}
