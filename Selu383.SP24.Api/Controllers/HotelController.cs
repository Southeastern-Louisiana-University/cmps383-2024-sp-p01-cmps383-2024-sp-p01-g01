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
         * 
         *  EVERYTHING COMMENTED BELOW THIS SHOULD WORK WHEN DATABASE IS CONNECTED
         * 
        [HttpDelete("{id}")]
        public ActionResult<HotelDto> DeleteAppointment(int id)
        {
            var targetHotel = DataContext.Set<Hotel>().FirstOrDefault(x => x.Id == id);
            if (targetHotel == null)
            {
                return NotFound();
            }

            DataContext.Set<Hotel>().Remove(targetHotel);
            DataContext.SaveChanges();

            return Ok(new HotelDto
            {
                Id = x.Id,
                Name = x.Name,
                Address = x.Address
            });
        }
        */

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
            return
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
