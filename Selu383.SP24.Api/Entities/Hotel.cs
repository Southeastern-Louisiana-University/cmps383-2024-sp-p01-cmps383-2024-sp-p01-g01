
namespace Selu383.SP24.Api.Entities
{
    public class Hotel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
    }

    public class HotelDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
    }

    public class HotelGetDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
    }

    public class HotelCreateDto
    {
        public string? Name { get; set; }
        public string? Address { get; set; }
    }

    public class HotelUpdateDto
    {
        public string? Name { get; set; }
        public string? Address { get; set; }
    }

    public class HotelListingDto
    {
        public string? Name { get; set; }
        public string? Address { get; set; }
    }
}
