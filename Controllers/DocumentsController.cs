using ASDP.FinalProject.UseCases.Documents.Queries;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ASDP.FinalProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public DocumentsController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet("loadTemplates")]
        public async Task<IActionResult> GetTemplates()
        {
            var res = await _mediator.Send(new GetTemplatesQuery());
            return Ok(res);
        }
    }
}
