using Domain.Entities;

namespace Infrastructure.MessageQueue
{
    public interface IQueueClient
    {
        void Send(GeoRequest request);
    }
}
