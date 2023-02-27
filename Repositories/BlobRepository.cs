﻿using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using StorageWebApp.Models;

namespace StorageWebApp.Repositories
{
    public class BlobRepository : IBlobRepository
    {
        private static string connectionString = "DefaultEndpointsProtocol=https;AccountName=pavitrastorage;AccountKey=WcP5EsCxivIaTnTIv0N1knfFU8s76p9A5fjvXfXhuw5nofUdiYO4geSUFpCUsR978aSmKxFPlTNC+AStk9CrmA==;EndpointSuffix=core.windows.net";
        private readonly CloudBlobContainer _container;
        public BlobRepository(string connectionString, string containername)
        {
            var blobClient = CloudStorageAccount.Parse("DefaultEndpointsProtocol=https;AccountName=pavitrastorage;AccountKey=WcP5EsCxivIaTnTIv0N1knfFU8s76p9A5fjvXfXhuw5nofUdiYO4geSUFpCUsR978aSmKxFPlTNC+AStk9CrmA==;EndpointSuffix=core.windows.net").CreateCloudBlobClient();
            _container = blobClient.GetContainerReference("pavitracontainer");
        }
        public async Task<BlobStorage> GetFileAsync(string fileName )
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
        public async Task<BlobStorage> AddFileAsync(string fileName,Stream stream)
        {
            var blob = _container.GetBlockBlobReference(fileName);
            await blob.UploadFromStreamAsync(stream);
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
