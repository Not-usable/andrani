using Application.Interfaces.Services;

namespace Application.Interfaces.MessageQueue
{
    public interface IResponseQueueClient
    {
        void Send(GeoResponseMessage request);
    }
}
