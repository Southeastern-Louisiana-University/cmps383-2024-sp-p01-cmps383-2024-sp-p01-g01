using Microsoft.AspNetCore.Mvc;
using Selu383.SP24.Api.Entities;

namespace Selu383.SP24.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HotelController : ControllerBase
    {
        private readonly ILogger<HotelController> _logger;

        public HotelController(ILogger<HotelController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var Hotels = new Hotel
            {
                Id = 1,
                Name = "Hotel BnB",
                Address = "1337 Hammond Drive"
            };

            return Ok(Hotels);
        }
    }
}
