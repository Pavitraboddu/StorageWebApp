namespace StorageWebApp.Repositories
{
    public interface IQueueRepository
    {
        Task<string> CreateQueue(string queueName);
        Task<string> DeleteQueue(string queueName);
        Task<string> InsertQueue(string queueName, string message);
    }
}
