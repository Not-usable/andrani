using Application.Features.GeoRequest.Responses;
using Application.Interfaces.Repositories;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.GeoRequest.Commands
{
    public class CreateGeoRequestCommand : BaseGeoRequestCommand, IRequest<GeoRequestResponse> { }

    public class CreateGeoRequestCommandHandler : IRequestHandler<CreateGeoRequestCommand, GeoRequestResponse>
    {
        private readonly IGeoRequestRepository _GeoRequestRepository;
        private readonly IMapper _mapper;
        public CreateGeoRequestCommandHandler(IGeoRequestRepository ProductRepository, IMapper mapper)
        {
            _GeoRequestRepository = ProductRepository;
            _mapper = mapper;
        }

        public async Task<GeoRequestResponse> Handle(CreateGeoRequestCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Domain.Entities.GeoRequest>(request);
            var response = await _GeoRequestRepository.AddAsync(entity);
            return _mapper.Map<GeoRequestResponse>(response);
        }
    }
}
