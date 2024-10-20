using ASDP.FinalProject.DAL.Models;
using ASDP.FinalProject.Dtos.Sigex;
using ASDP.FinalProject.Helpers;
using ASDP.FinalProject.UseCases.Authorization.Commands;
using ASDP.FinalProject.UseCases.Authorization.Dtos;
using ASDP.FinalProject.UseCases.Authorization.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        [HttpGet("nonce-block")]
        [ProducesResponseType<SigexAuthNonceResponse>(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetNonceBlock()
        {
            var s = HttpContext.Request.Cookies;
            return Ok(await _mediator.Send(new GetNonceBlockQuery()));
        }

        [HttpPost("authorize-nca")]
        [ProducesResponseType<AuthDataResponse>(StatusCodes.Status200OK)]
        public async Task<IActionResult> Authorize(AuthUsingNcaRequest data)
        {
            var s = HttpContext.Request.Cookies;
            return Ok(await _mediator.Send(data));
        }

    }
}
