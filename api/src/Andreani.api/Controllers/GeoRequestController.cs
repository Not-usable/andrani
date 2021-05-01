using Application.Features.GeoRequest.Commands;
using Application.Features.GeoRequest.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.CodeAnalysis;

namespace E_Commers.Controllers
{
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Produces("application/json")]
    [Route("[controller]")]
    public class GeoRequestController : BaseApiController
    {
        public GeoRequestController() { }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(GeoRequestResponse), StatusCodes.Status200OK)]
        public async System.Threading.Tasks.Task<IActionResult> GetProductAsync(int id)
        {
            return Ok(await Mediator.Send(new GetGeoRequestCommand() { Id = id }));
        }

        [HttpPost]
        [ProducesResponseType(typeof(GeoRequestResponse), StatusCodes.Status201Created)]
        public async System.Threading.Tasks.Task<IActionResult> PostProductAsync(CreateGeoRequestCommand product)
        {
            return Created(await Mediator.Send(product));
        }
    }
}
