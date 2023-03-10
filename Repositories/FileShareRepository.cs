using Azure;
using Azure.Storage.Blobs;
using Azure.Storage.Files.Shares;
using StorageWebApp.Models;

namespace StorageWebApp.Repositories
{
    public class FileShareRepository : IFileShareRepository
    {
        private static string connectionString = "DefaultEndpointsProtocol=https;AccountName=pavitrastorage;AccountKey=W0zwHK3hjFqHGy7t29go1HamiPlAIZP0Kkj8ccLcqs0YEgSqx0YVmWds7NAMaQjYYTs+dmfK3y7p+AStrBCI5A==;EndpointSuffix=core.windows.net";
        private static string fileShareName = "pavitrafile";
        //private static string ShareClient shareClient;

        public FileShareRepository()
        {

        }
        public async Task<byte[]> DownloadFile(string fileName)
        {
            var shareClient = new ShareClient(connectionString, fileShareName);
            var shareDirectoryClient = shareClient.GetDirectoryClient("");
            var shareFileClient = shareDirectoryClient.GetFileClient(fileName);
            var response = await shareFileClient.DownloadAsync();
            using var memoryStream = new MemoryStream();
            await response.Value.Content.CopyToAsync(memoryStream);
            return memoryStream.ToArray();
        }
        public async Task<bool> UploadFile(IFormFile file)
        {
            var shareClient = new ShareClient(connectionString, fileShareName);
            var shareDirectoryClient = shareClient.GetDirectoryClient("");
            var shareFileClient = shareDirectoryClient.GetFileClient(file.FileName);
            using (var stream = file.OpenReadStream())
            {
                shareFileClient.Create(stream.Length);
                await shareFileClient.UploadRangeAsync(new HttpRange(0, file.Length), stream);
            }
            return true;
        }
        public async Task<bool> DeleteFile(string fileName)
        {
            var shareClient = new ShareClient(connectionString, fileShareName);
            var shareDirectoryClient = shareClient.GetDirectoryClient("");
            var shareFileClient = shareDirectoryClient.GetFileClient(fileName);
            await shareFileClient.DeleteAsync();
            return true;
        }
    }
}

