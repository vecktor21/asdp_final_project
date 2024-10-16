using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASDP.FinalProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthorizeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        
    }
}
