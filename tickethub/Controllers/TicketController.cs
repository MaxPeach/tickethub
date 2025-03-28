using Azure.Storage.Queues;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices.Marshalling;
using System.Text.Json;
////done
namespace tickethub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IConfiguration _configuration;
        public TicketController(ILogger<TicketController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        [HttpGet]
        public  IActionResult Get(Ticket ticket)
        {
            return Ok("Hello from Ticket Controller");
        }

        [HttpPost]
        public async Task<IActionResult> Post(Ticket ticket)
        {

            if (ModelState.IsValid == false) 
            {
                return BadRequest(ModelState);
            }
            //
            //post to que
            //
            string queueName = "purchases";

            // Get connection string from secrets.json
            string? connectionString = _configuration["AzureStorageConnectionString"];

            if (string.IsNullOrEmpty(connectionString))
            {
                return BadRequest("An error was encountered");
            }
            QueueClient queueClient = new QueueClient(connectionString, queueName);

            // serialize an object to json
            string message = JsonSerializer.Serialize(ticket);

            // send string message to queue
            await queueClient.SendMessageAsync(message);

            return Ok("Hello " + ticket.Name + ", enjoy the show!");
        }   
    }
}
