﻿using ASDP.FinalProject.UseCases.Signing.Commands;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ASDP.FinalProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SignController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public SignController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost("registerDocument")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> CreateSignPipeline([FromForm] CreateSignPipelineContract data,
            [FromHeader] string Authorization)
        {
            var req = _mapper.Map<CreateSignPipelineRequest>(data);
            req.Token = Authorization;
            await _mediator.Send(req);
            return Ok();
        }

    }
}