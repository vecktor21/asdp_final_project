using ASDP.FinalProject.DAL.Models;
using ASDP.FinalProject.Dtos.Sigex;
using ASDP.FinalProject.Helpers;
using ASDP.FinalProject.UseCases.Authorization.Commands;
using ASDP.FinalProject.UseCases.Authorization.Dtos;
using ASDP.FinalProject.UseCases.Authorization.Queries;
using ASDP.FinalProject.UseCases.Employees.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Newtonsoft.Json.Linq;
using Org.BouncyCastle.Asn1.Ocsp;
using System.IO;
using System.Net;
using System.Text;
using System.Text.Json;

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
