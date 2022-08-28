using KapitalMedya.Application.Repositories.Bookings;
using KapitalMedya.Domain.Entities;
using KapitalMedya.Persistence.Contexts;

namespace KapitalMedya.Persistence.Repositories.Bookings
{
    public class BookingReadRepository : ReadRepository<Booking>, IBookingReadRepository
    {
        public BookingReadRepository(KapitalMedyaDbContext context) : base(context)
        {
        }
    }
}
