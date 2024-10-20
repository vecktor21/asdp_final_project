using ASDP.FinalProject.UseCases.Documents.Commands;
using ASDP.FinalProject.UseCases.Documents.Dtos;
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
        [ProducesResponseType<List<TemplateResponse>>(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetTemplates()
        {
            var res = await _mediator.Send(new GetTemplatesQuery());
            return Ok(res);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="name">template name</param>
        /// <param name="file">load template</param>
        /// <returns></returns>
        [HttpPost("addTemplate")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> AddTemplate([FromForm] string name, IFormFile file)
        {
            byte[] data;
            //var file = HttpContext.Request.Form.Files[0];

            using (var ms = new MemoryStream())
            {
                file.CopyTo(ms);
                data = ms.ToArray();
            }

            var res = await _mediator.Send(new AddTemplateRequest
            {
                Content = data,
                Name = name,
                ContentType = file.ContentType

            });
            return Ok();
        }
    }
}
