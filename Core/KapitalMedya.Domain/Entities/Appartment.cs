using KapitalMedya.Domain.Entities.Common;

namespace KapitalMedya.Domain.Entities
{
    public class Appartment : BaseEntity
    {
        public string? Name { get; set; }
        public string? Image { get; set; }
        public string? Country { get; set; }
        public string? City { get; set; }
        public string? ZipCode { get; set; }
        public string? Address { get; set; }
        public string? Address2 { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public string? Direction { get; set; }
        public int? Booked { get; set; }
    }
}
