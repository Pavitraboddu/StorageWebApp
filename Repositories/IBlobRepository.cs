using StorageWebApp.Models;
using System.Reflection.Metadata;

namespace StorageWebApp.Repositories
{
    public interface IBlobRepository
    {
        Task<BlobStorage> AddFileAsync(string fileName);
        Task DeleteFileAsync(string fileName);
        Task<BlobStorage> GetFileAsync(string fileName);
    }
}
