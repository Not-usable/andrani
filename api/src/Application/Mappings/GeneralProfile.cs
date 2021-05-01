using Application.Features.Category.Commands;
using Application.Features.Category.Responses;
using Application.Features.GeoRequest.Commands;
using Application.Features.GeoRequest.Responses;
using Application.Features.User.Commands;
using Application.Features.User.Responses;
using AutoMapper;

namespace Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        { 
            CreateMap<CreateUserCommand, Domain.Entities.User>(); 

            CreateMap<Domain.Entities.User, UserResponse>();


            CreateMap<CreateCategoryCommand, Domain.Entities.Category>();

            CreateMap<Domain.Entities.Category, CategoryResponse>();


            CreateMap<CreateGeoRequestCommand, Domain.Entities.Product>();

            CreateMap<Domain.Entities.Product, GeoRequestResponse>();
        }
    }
}
