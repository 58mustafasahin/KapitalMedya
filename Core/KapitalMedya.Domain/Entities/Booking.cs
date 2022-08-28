using KapitalMedya.Domain.Entities.Common;

namespace KapitalMedya.Domain.Entities
{
    public class Booking : BaseEntity
    {
        public int? UserId { get; set; }
        public string? StartsAt { get; set; }
        public string? BookedAt { get; set; }
        public int? BookedFor { get; set; }
        public int? ApartmentId { get; set; }
        public int? Confirmed { get; set; }
    }
}
