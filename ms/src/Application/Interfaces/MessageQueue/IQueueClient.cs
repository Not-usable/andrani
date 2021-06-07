using Domain.Entities;

namespace Application.Interfaces.MessageQueue
{
    public interface IQueueClient
    {
        void Send(GeoRequest request);
    }
}
