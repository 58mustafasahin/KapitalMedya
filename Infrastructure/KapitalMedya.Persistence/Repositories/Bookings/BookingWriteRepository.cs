using KapitalMedya.Application.Repositories.Bookings;
using KapitalMedya.Domain.Entities;
using KapitalMedya.Persistence.Contexts;

namespace KapitalMedya.Persistence.Repositories.Bookings
{
    public class BookingWriteRepository : WriteRepository<Booking>, IBookingWriteRepository
    {
        public BookingWriteRepository(KapitalMedyaDbContext context) : base(context)
        {
        }
    }
}
