using StorageWebApp.Models;
using System.Reflection.Metadata;

namespace StorageWebApp.Repositories
{
    public interface IBlobRepository
    {
        Task<BlobStorage> AddFileAsync(string fileName, Stream stream);
        Task DeleteFileAsync(string fileName);
        Task<BlobStorage> GetFileAsync(string fileName);
    }
}
