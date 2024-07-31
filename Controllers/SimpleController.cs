using Microsoft.AspNetCore.Mvc;
using System;
using Models;

namespace SimpleApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SimpleController : ControllerBase
    {
        // GET api/simple
        [HttpGet]
        public IActionResult Get()
        {
            var response = new
            {
                Id = Guid.NewGuid(),
                Name = "Sample Item",
                Description = "This is a description of the item.",
                Price = 19.99,
                Available = true,
                Timestamp = DateTime.UtcNow
            };

            return Ok(response);
        }
    }
}
