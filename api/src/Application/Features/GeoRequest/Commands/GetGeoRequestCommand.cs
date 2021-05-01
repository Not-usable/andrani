using Application.Features.GeoRequest.Responses;
using Application.Interfaces.Repositories;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.GeoRequest.Commands
{
    public class GetGeoRequestCommand : IRequest<GeoRequestResponse>
    {
        public int Id { get; set; }
    }

    public class GetProductCommandHandler : IRequestHandler<GetGeoRequestCommand, GeoRequestResponse>
    {
        private readonly IGeoRequestRepository _ProductRepository;
        private readonly IMapper _mapper;
        public GetProductCommandHandler(IGeoRequestRepository ProductRepository, IMapper mapper)
        {
            _ProductRepository = ProductRepository;
            _mapper = mapper;
        }

        public Task<GeoRequestResponse> Handle(GetGeoRequestCommand request, CancellationToken cancellationToken)
        {
            var response = _ProductRepository.Find(request.Id);
            return Task.FromResult(_mapper.Map<GeoRequestResponse>(response));
        }
    }
}
