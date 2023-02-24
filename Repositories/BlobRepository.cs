using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Routing.Constraints;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using StorageWebApp.Models;
using System.Reflection.Metadata;

namespace StorageWebApp.Repositories
{
    public class BlobRepository : IBlobRepository
    {
        private readonly CloudBlobContainer _container;
        public BlobRepository(string connectionString, string containername)
        {
            var blobClient = CloudStorageAccount.Parse(connectionString).CreateCloudBlobClient();
            _container = blobClient.GetContainerReference(containername);
        }
        public async Task<BlobStorage> GetFileAsync(string fileName)
        {
            var blob = _container.GetBlockBlobReference(fileName);
            if (await blob.ExistsAsync())
            {
                return new BlobStorage
                {
                    FileName = fileName,
                    BlobUrl = blob.Uri.AbsoluteUri
                };
            }
            return null;

        }
        public async Task<BlobStorage> AddFileAsync(string fileName)
        {
            var blob = _container.GetBlockBlobReference(fileName);
            return new BlobStorage
            {
                FileName = fileName,
                BlobUrl = blob.Uri.AbsoluteUri
            };
        }
        public async Task DeleteFileAsync(string fileName)
        {
            var blob = _container.GetBlockBlobReference(fileName);
            await blob.DeleteAsync();
        }
    }
}
