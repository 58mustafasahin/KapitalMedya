namespace KapitalMedya.Application.Features.Bookings.Dtos
{
    public class GetBookingDto
    {
        public int? Id { get; set; }
        public int? UserId { get; set; }
        public int? ApartmentId { get; set; }
        public UserDto users { get; set; } = new UserDto();
        public AppartmentDto appartments { get; set; } = new AppartmentDto();
        public string? StartsAt { get; set; }
        public string? FinishAt { get; set; }
        public int? BookedFor { get; set; }
        public int? Confirmed { get; set; }
    }

    public class UserDto
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
    }

    public class AppartmentDto
    {
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? ZipCode { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
    }
}
