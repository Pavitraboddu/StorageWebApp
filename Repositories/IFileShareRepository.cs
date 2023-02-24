using StorageWebApp.Models;

namespace StorageWebApp.Repositories
{
    public interface IFileShareRepository
    {
        Task CreateFileAsync(string fileShareName);
        Task DeleteFileAsync(string fileShareName);
        Task Upload(FileModel model);
    }
}
