using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;

namespace E_Commers.Controllers
{
    [ExcludeFromCodeCoverage]
    public abstract class BaseApiController : ControllerBase
    {
        private IMediator _mediator;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        [ApiExplorerSettings(IgnoreApi = true)]
        public ObjectResult Created([ActionResultObjectValue] object value)
        {
            return new ObjectResult(value)
            {
                StatusCode = StatusCodes.Status201Created
            };
        }
    }
}
