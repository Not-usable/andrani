using Application.Features.GeoRequest.Commands;
using Application.Features.GeoRequest.Responses;
using AutoMapper;

namespace Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        { 
            CreateMap<CreateGeoRequestCommand, Domain.Entities.GeoRequest>();

            CreateMap<Domain.Entities.GeoRequest, GeoRequestCreatedResponse>();
            CreateMap<Domain.Entities.GeoRequest, GeoRequestResponse>();
        }
    }
}
