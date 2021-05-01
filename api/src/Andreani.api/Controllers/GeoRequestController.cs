using Application.Features.GeoRequest.Commands;
using Application.Features.GeoRequest.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;

namespace Andreani.Controllers
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
            /*HttpClient httpClient = new HttpClient { BaseAddress = new Uri("http://nominatim.openstreetmap.org/") }; //https://nominatim.openstreetmap.org/search?q=135+pilkington+avenue,+birmingham&format=json&addressdetails=1
            httpClient.DefaultRequestHeaders.Add("User-Agent", "geo api andreani");
            HttpResponseMessage httpResult = await httpClient.GetAsync(
                String.Format("search?q={0}&format=json&addressdetails=1", "157+riverside+avenue,+champaign,+il+55555+(USA)"));

            var result = await httpResult.Content.ReadAsStringAsync();*/

            return Ok(await Mediator.Send(new GetGeoRequestCommand() { Id = id }));
        }

        [HttpPost]
        [ProducesResponseType(typeof(GeoRequestCreatedResponse), StatusCodes.Status201Created)]
        public async System.Threading.Tasks.Task<IActionResult> PostProductAsync(CreateGeoRequestCommand product)
        {
            return Created(await Mediator.Send(product));
        }
    }
}
