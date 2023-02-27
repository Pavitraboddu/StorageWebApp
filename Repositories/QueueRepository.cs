using Azure.Storage.Queues;
using System.Configuration;

namespace StorageWebApp.Repositories
{
    public class QueueRepository : IQueueRepository
    {
        private static string connectionString = "DefaultEndpointsProtocol=https;AccountName=pavitrastorage;AccountKey=WcP5EsCxivIaTnTIv0N1knfFU8s76p9A5fjvXfXhuw5nofUdiYO4geSUFpCUsR978aSmKxFPlTNC+AStk9CrmA==;EndpointSuffix=core.windows.net";
       // private static string queueName = "queue1";
        public async Task<string> CreateQueue(string queuename)
        {
            try
            {
                QueueClient queueClient = new QueueClient(connectionString, queuename);
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
        public async Task<string> DeleteQueue(string queuename)
        {
            QueueClient queueClient = new QueueClient(connectionString, queuename);
            if (queueClient.Exists())
            {
                queueClient.Delete();
                return " Queue is deleted";
            }
            return "Queue is not deleted";
        }
        public async Task<string> InsertQueue(string queuename, string message)
        {
            QueueClient queueClient = new QueueClient(connectionString, queuename);
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
