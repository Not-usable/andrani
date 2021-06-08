using Application.Features.GeoRequest.Responses;
using Application.Interfaces.Services;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.GeoRequest.Commands
{
    public class GetCoordinatesFromDirectionsCommand : Address, IRequest<GetCoordinatesFromDirectionResponse>
    {
        public int Id { get; set; }
    }

    public class GetCoordinatesFromDirectionsCommandHandler : IRequestHandler<GetCoordinatesFromDirectionsCommand, GetCoordinatesFromDirectionResponse>
    {
        private readonly IGeoService _service;
        private readonly IMapper _mapper ;

        public GetCoordinatesFromDirectionsCommandHandler(IGeoService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public async Task<GetCoordinatesFromDirectionResponse> Handle(GetCoordinatesFromDirectionsCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Domain.Entities.Address>(request);
            var response = _mapper.Map<GetCoordinatesFromDirectionResponse>(await _service.CompleteCoordinatesAsync(entity));
            response.Id = request.Id;

            return response;
        }
    }
}
