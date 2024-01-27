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
         * THIS SHOULD WORK WHEN DATABASE IS UP
         * 
        [HttpDelete("{id}")]
        public ActionResult<HotelDto> DeleteAppointment(int id)
        {
            var targetAppointment = DataContext.Set<Hotel>().FirstOrDefault(x => x.Id == id);
            if (targetAppointment == null)
            {
                return NotFound();
            }

            DataContext.Set<Hotel>().Remove(targetAppointment);
            DataContext.SaveChanges();

            return Ok(new AppointmentDto
            {
                Id = x.Id,
                Name = x.Name,
                Address = x.Address
            });
        }
        */

        /*
         * 
         * THESE SHOULD WORK WHEN DATABASE IS UP
         * 
         * 
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
