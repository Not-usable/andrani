using Application.Interfaces.MessageQueue;
using Application.Interfaces.Repositories;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.GeoRequest.Commands
{
    public class UpdateCoordinatesGeoRequestCommand: IRequest
    {
        public int Id { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
    }

    public class UpdateCoordinatesGeoRequestCommandHandler : IRequestHandler<UpdateCoordinatesGeoRequestCommand>
    {
        private readonly IGeoRequestRepository _GeoRequestRepository;
        private readonly IQueueClient _queueClient;
        public UpdateCoordinatesGeoRequestCommandHandler(IGeoRequestRepository ProductRepository, IQueueClient queueClient)
        {
            _GeoRequestRepository = ProductRepository;
            _queueClient = queueClient;
        }

        public async Task<Unit> Handle(UpdateCoordinatesGeoRequestCommand request, CancellationToken cancellationToken)
        {
            var entity = _GeoRequestRepository.Find(request.Id);
            entity.Status = "TERMINADO";
            entity.Longitude = request.Longitude;
            entity.Latitude = request.Latitude;
            var response = await _GeoRequestRepository.UpdateAsync(entity);
            _queueClient.Send(response);
            return Unit.Value;
        }
    }
}
