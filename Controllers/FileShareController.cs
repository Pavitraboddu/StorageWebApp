using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StorageWebApp.Models;
using StorageWebApp.Repositories;
using System.IO;

namespace StorageWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileShareController : ControllerBase
    {
        private readonly FileShareRepository repository;
        public FileShareController(FileShareRepository repository)
        {
            this.repository = repository;
        }
        [HttpPost("create")]
        public async Task<IActionResult> CreateFileAsync(string fileShareName)
        {
            await repository.CreateFileAsync(fileShareName);
            return Ok();
        }

        [HttpPut("Upload")]
        public async Task<IActionResult> Upload([FromForm] FileModel model)
        {
            if (model.ImageFile != null)
            {
                await repository.Upload(model);
            }
            return Ok();
        }
        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteFileAsync(string fileShareName)
        {
            await repository.DeleteFileAsync(fileShareName);
            return Ok();
        }
    }
}
