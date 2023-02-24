using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StorageWebApp.Repositories;

namespace StorageWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QueueController : ControllerBase
    {
        static readonly IQueueRepository repository = new QueueRepository();
        [HttpPost("create")]
        public async Task<IActionResult> CreateQueue(string queueName)
        {
            await repository.CreateQueue(queueName);
            return Ok();
        }
        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteQueue(string queueName)
        {
            await repository.DeleteQueue(queueName);
            return Ok();
        }
        [HttpPut("Insert")] 
        public async Task<IActionResult> InsertQueue(string queueName, string message)
        {
            var result = await repository.InsertQueue(queueName, message);
            return Ok(result);
        }
    }
}
