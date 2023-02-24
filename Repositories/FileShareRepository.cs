using Azure.Storage.Blobs;
using Azure;
using Azure.Storage.Files.Shares;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.Dynamic;
using System.IO;
using System.Net;
using System.Reflection.PortableExecutable;
using System;
using System.Security.Cryptography.X509Certificates;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;
using System.Reflection.Metadata.Ecma335;
using StorageWebApp.Models;

namespace StorageWebApp.Repositories
{
    public class FileShareRepository : IFileShareRepository
    {
        private static string connectionString = "";
        public async Task CreateFileAsync(string fileShareName)
        {
            ShareClient share = new ShareClient(connectionString, fileShareName);
            await share.CreateIfNotExistsAsync();
            if (await share.ExistsAsync())
            {
                Console.WriteLine($"Share created: {share.Name}");

            }
            else
            {
                Console.WriteLine($"CreateFileAsync failed");
            }
        }
        public async Task DeleteFileAsync(string fileShareName)
        {
            ShareClient share = new ShareClient(connectionString, fileShareName);
            await share.DeleteIfExistsAsync();
        }
        private readonly BlobServiceClient _blobServiceClient;
        public FileShareRepository(BlobServiceClient blobServiceClient)
        {
            _blobServiceClient = blobServiceClient;
        }

        public async Task Upload(FileModel model)
        {
            var blobContainer = _blobServiceClient.GetBlobContainerClient("Container name");

            var blobClient = blobContainer.GetBlobClient(model.ImageFile.FileName);

            await blobClient.UploadAsync(model.ImageFile.OpenReadStream());
        }
    }
}

