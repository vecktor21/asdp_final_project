using ASDP.FinalProject.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Serilog;

namespace ASDP.FinalProject.Filter
{
    public class AdspExceptionFilter : ExceptionFilterAttribute
    {
        public override Task OnExceptionAsync(ExceptionContext context)
        {
            switch (context.Exception)
            {
                case AsdpException e:
                    context.Result = new BadRequestObjectResult(e.Result);
                    Log.Logger.Warning(e.Message);
                    break;
                default:
                    break;
            }
            return base.OnExceptionAsync(context);
        }
    }
}
