using Azure.Storage.Queues;
using System.Configuration;

namespace StorageWebApp.Repositories
{
    public class QueueRepository : IQueueRepository
    {
        private static string connectionString = "";
        public async Task<string> CreateQueue(string queueName)
        {
            try
            {
                QueueClient queueClient = new QueueClient(connectionString, queueName);
                queueClient.CreateIfNotExists();
                if (queueClient.Exists())
                {
                    return "Queue successfully created ";
                }
                return "Queue is not created";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<string> DeleteQueue(string queueName)
        {
            QueueClient queueClient = new QueueClient(connectionString, queueName);
            if (queueClient.Exists())
            {
                queueClient.Delete();
                return " Queue is deleted";
            }
            return "Queue is not deleted";
        }
        public async Task<string> InsertQueue(string queueName, string message)
        {
            QueueClient queueClient = new QueueClient(connectionString, queueName);
            queueClient.CreateIfNotExists();
            if (queueClient.Exists())
            {
                queueClient.SendMessage(message);
                return "Message inserted";
            }
            return "Message is not  inserted";
        }

    }
}
