using Microsoft.AspNetCore.Mvc;
using System;
using Models;

namespace SimpleApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SimpleItemController : ControllerBase
    {
        // GET api/simple
        [HttpGet]
        public IActionResult Get()
        {
            var response = new SimpleItem
            {
                Id = Guid.NewGuid(),
                Name = "Sample Simple Item",
                Description = "This is a description of the item.",
                Price = new decimal(29.99),
                Available = true,
                Timestamp = DateTime.UtcNow
            };

            return Ok(response);
        }
    }
}
