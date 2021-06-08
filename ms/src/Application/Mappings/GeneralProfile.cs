using Application.Features.GeoRequest.Commands;
using Application.Features.GeoRequest.Responses;
using AutoMapper;

namespace Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        { 
            CreateMap<GetCoordinatesFromDirectionsCommand, Domain.Entities.Address>();
            CreateMap<Domain.Entities.Coordinates, GetCoordinatesFromDirectionResponse>();
        }
    }
}
