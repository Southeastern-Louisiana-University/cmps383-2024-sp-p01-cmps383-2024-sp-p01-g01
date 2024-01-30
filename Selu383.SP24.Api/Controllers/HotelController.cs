using Microsoft.AspNetCore.Mvc;
using Selu383.SP24.Api.Entities;
using Selu383.SP24.Api.Controllers;
using Microsoft.EntityFrameworkCore;

namespace Selu383.SP24.Api.Controllers
{
    [ApiController]
    [Route("api/hotels")]
    public class HotelController : ControllerBase
    {
        private readonly ILogger<HotelController> _logger;
        private DataContext _context;

        public HotelController(ILogger<HotelController> logger, DataContext context)
        {
            _logger = logger;
            _context = context;
        }


        [HttpGet]
        public ActionResult<HotelDto[]> Get()
        {
            var result = _context.Hotels;
            return Ok(result.Select(x => new HotelDto
            {
                Id = x.Id,
                Name = x.Name,
                Address = x.Address,
            }));
        }


        [HttpGet("{Id}")]
        public ActionResult<HotelDto> Details([FromRoute] int Id)
        { 

            var HotelReturn = _context.Hotels.FirstOrDefault(x => x.Id == Id);

            if (HotelReturn == null)
            {
                return NotFound($"Unable to find Id {Id}");
            }

            return Ok(new HotelDto
            {
                Id = HotelReturn.Id,
                Name = HotelReturn.Name,
                Address = HotelReturn.Address,
            });
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



    }
}
