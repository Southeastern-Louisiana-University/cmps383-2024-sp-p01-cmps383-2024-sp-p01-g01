using Microsoft.AspNetCore.Mvc;
using Selu383.SP24.Api.Entities;
using Selu383.SP24.Api.Controllers;
using Microsoft.EntityFrameworkCore;
using Azure;
using System.Net;
using Selu383.SP24.Api.FixToPut;
using static System.Collections.Specialized.BitVector32;

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

        [HttpPut("{id}")]
        public IActionResult Edit(int Id, [FromBody] HotelDto hotelDto)
        {
            var response = new FixToPut.Response();

            var HotelToEdit = _context.Hotels.FirstOrDefault(x => x.Id == Id);

            if (!ModelState.IsValid) 
            {
                return BadRequest(ModelState);
            }


            if (HotelToEdit == null)
            {
                return NotFound();
            }
            if (hotelDto == null)
            {
                return NotFound(response);
            }
            if (string.IsNullOrEmpty(hotelDto.Name))
            {
                response.AddError("Name", "Name must be provided ");
                return BadRequest(response);

            }
            if (hotelDto.Name!.Length > 120)
            {
                response.AddError("Name", "Name cannot be longer than 120 characters");
            }
            if (hotelDto.Address == null)
            {
                response.AddError("Address", "Must have an address");
            }
            if (hotelDto.Address == "")
            {
                response.AddError("Address", "Must have address");
            }
            if (response.HasErrors)
            {
                return BadRequest(response);
            }

            HotelToEdit.Name = hotelDto.Name;
            HotelToEdit.Address = hotelDto.Address;

            _context.SaveChanges();

            hotelDto.Id = HotelToEdit.Id;


            return Ok(hotelDto);
        }

        [HttpDelete]
        [Route("{Id}")]
        public ActionResult<HotelDto> DeleteHotel([FromRoute] int Id)
        {

            var HotelDelete = _context.Hotels.Find(Id);
            if (HotelDelete == null)
            {
                return NotFound();
            }
            _context.Hotels.Remove(HotelDelete);
            _context.SaveChanges();

            


            return Ok("Deleted.");
        }









    }
}
