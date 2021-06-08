using Application.Features.GeoRequest.Responses;

namespace Application.Interfaces.MessageQueue
{
    public interface IResponseQueueClient
    {
        void Send(GetCoordinatesFromDirectionResponse request);
    }
}
