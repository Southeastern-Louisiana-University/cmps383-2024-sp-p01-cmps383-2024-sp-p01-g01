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
                return NotFound($"Can't find Id: {Id}");
            }

            return Ok(new HotelDto
            {
                Id = HotelReturn.Id,
                Name = HotelReturn.Name,
                Address = HotelReturn.Address,
            });
        }

        [HttpPost]
        public ActionResult<HotelDto> Create(HotelDto Hotel)
        {
            if (string.IsNullOrEmpty(Hotel.Name))
            {
                return BadRequest("Must have a name");
            }
            if (Hotel.Name.Length > 120)
            {
                return BadRequest("Name must not be longer than 120 characters");
            }
            if (string.IsNullOrEmpty(Hotel.Address))
            {
                return BadRequest("Must have an address");
            }

            var returnCreatedHotel = new Hotel
            {
                Name = Hotel.Name,
                Address = Hotel.Address,
            };
            _context.Hotels.Add(returnCreatedHotel);
            _context.SaveChanges();

            Hotel.Id = returnCreatedHotel.Id;

            return CreatedAtAction(nameof(Details), new { Id = returnCreatedHotel.Id }, returnCreatedHotel);

        }






       



    }
}
