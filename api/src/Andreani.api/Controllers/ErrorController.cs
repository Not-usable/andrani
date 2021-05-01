using E_Commers.Errors;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics.CodeAnalysis;

namespace E_Commers.Controllers
{
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Produces("application/json")]
    [Route("[controller]")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ErrorController : ControllerBase
    {
        private readonly ILogger<ErrorController> _logger;
        private readonly ErrorManager _errorManager;

        public ErrorController(ILogger<ErrorController> logger, ErrorManager errorManager)
        {
            _logger = logger;
            _errorManager = errorManager;
        }

        [Route("/error")]
        public ObjectResult Error()
        {
            var error = HttpContext.Features.Get<IExceptionHandlerFeature>().Error;

            _logger.LogError(error, error.Message);

            return _errorManager.GetResponse(error).GetResult();
        }
    }
}
