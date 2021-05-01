namespace Infrastructure.MessageQueue
{
    public interface IQueueClient
    {
        void Send(int id);
    }
}
