using Microsoft.AspNetCore.Mvc;
using Album.Api.Models;
using Microsoft.Extensions.Logging;
using System;

namespace Album.Api.Controllers
{
    [ApiController]
    public class HelloController : Controller
    {
        private readonly ILogger<HelloController> _logger;
        public HelloController(ILogger<HelloController> logger)
        {
            _logger = logger;
        }

        [HttpGet("api/hello/{name?}")]
        public IActionResult Get(string name)
        {
            _logger.LogInformation("Hello Api is called", DateTime.UtcNow.ToLongTimeString());
            GreetingService greetingService = new GreetingService();
            Response res = greetingService.Greet(name);

            if (res == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(res);
            }
        }


    }
}
