using ASDP.FinalProject.UseCases.Signing.Commands;
using ASDP.FinalProject.UseCases.Signing.Dtos;
using ASDP.FinalProject.UseCases.Signing.Queries;
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

        /// <summary>
        /// создать очередь подписания
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost("registerSignPipeline")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> CreateSignPipeline([FromForm] CreateSignPipelineRequest data)
        {
            await _mediator.Send(data);
            return Ok();
        }

        /// <summary>
        /// получить созданные очереди подписания
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpGet("createdSignPipelines")]
        [ProducesResponseType<List<DocumentToSignDto>>(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetCreatedSignPipelines([FromQuery]int userId)
        {
            return Ok( await _mediator.Send(new GetCreatedSignPipelinesQuery { UserId = userId}));
        }

        /// <summary>
        /// получить документы которые надо подписать
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpGet("documentsToSign")]
        [ProducesResponseType<List<DocumentToSignDto>>(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetDocumentsToSign([FromQuery] int userId)
        {
            return Ok(await _mediator.Send(new GetSignPipelinesToSignQuery { UserId = userId }));
        }

        /// <summary>
        /// подписать документ
        /// </summary>
        /// <param name="signData"></param>
        /// /// <param name="signData.isSign">флаг - подписать или отклонить документ</param>
        /// <returns></returns>
        [HttpPost("signDocument")]
        public async Task<IActionResult> GetDocumentsToSign([FromBody]SignDocumentCommand signData)
        {
            return Ok(await _mediator.Send(signData));
        }

    }
}
