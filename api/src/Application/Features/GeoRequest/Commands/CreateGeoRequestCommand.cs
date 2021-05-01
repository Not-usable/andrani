using Application.Features.GeoRequest.Responses;
using Application.Interfaces.Repositories;
using AutoMapper;
using Infrastructure.MessageQueue;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.GeoRequest.Commands
{
    public class CreateGeoRequestCommand : BaseGeoRequestCommand, IRequest<GeoRequestCreatedResponse> { }

    public class CreateGeoRequestCommandHandler : IRequestHandler<CreateGeoRequestCommand, GeoRequestCreatedResponse>
    {
        private readonly IGeoRequestRepository _GeoRequestRepository;
        private readonly IMapper _mapper;
        private readonly IQueueClient _queueClient;
        public CreateGeoRequestCommandHandler(IGeoRequestRepository ProductRepository, IMapper mapper, IQueueClient queueClient)
        {
            _GeoRequestRepository = ProductRepository;
            _mapper = mapper;
            _queueClient = queueClient;
        }

        public async Task<GeoRequestCreatedResponse> Handle(CreateGeoRequestCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Domain.Entities.GeoRequest>(request);
            entity.Status = "PROCESANDO";
            var response = await _GeoRequestRepository.AddAsync(entity);
            _queueClient.Send(entity.Id);
            return _mapper.Map<GeoRequestCreatedResponse>(response);
        }
    }
}
