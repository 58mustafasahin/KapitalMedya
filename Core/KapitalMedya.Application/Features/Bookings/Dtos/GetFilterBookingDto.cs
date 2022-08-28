using KapitalMedya.Application.RequestParameter;

namespace KapitalMedya.Application.Features.Bookings.Dtos
{
    public class GetFilterBookingDto
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? StartDate { get; set; }
        public string? FinishDate { get; set; }
        public string? Name { get; set; }
        public int? Confirmed { get; set; }
        public PaginationEntity PaginationEntity { get; set; }
    }
}
