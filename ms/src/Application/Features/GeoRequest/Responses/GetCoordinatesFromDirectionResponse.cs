using Domain.Entities;

namespace Application.Features.GeoRequest.Responses
{
    public class GetCoordinatesFromDirectionResponse : Coordinates
    {
        public int Id { get; set; }
    }
}
