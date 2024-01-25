using Microsoft.AspNetCore.Mvc;
using Selu383.SP24.Api.Entities;
using Selu383.SP24.Api.Controllers;

namespace Selu383.SP24.Api.Controllers
{
    [ApiController]
    [Route("api/hotels")]
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


        /*
        [HttpPost]
        public ActionResult MakeHotel(HotelDto hotel)
        {
            DataContext.Set<Hotel>().Add(new hotel);
            DataContext.SaveChanges();

            return Ok(hotel);
        }
        */

        /*
        [HttpGet("all")]
        public List<HotelDto> GetAllHotels()
        {
            return DataContext.Set<HotelDto>()
                .Select(x => new HotelDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    Address = x.Address,
                })
                .ToList();
        }
        */
    }
}
