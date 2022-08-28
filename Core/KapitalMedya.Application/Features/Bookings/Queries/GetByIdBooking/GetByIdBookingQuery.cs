using KapitalMedya.Application.Features.Bookings.Dtos;
using KapitalMedya.Application.Repositories.Appartments;
using KapitalMedya.Application.Repositories.Bookings;
using KapitalMedya.Application.Repositories.Users;
using Mapster;
using MediatR;

namespace KapitalMedya.Application.Features.Bookings.Queries.GetByIdBooking
{
    public class GetByIdBookingQuery : IRequest<GetBookingDto>
    {
        public int Id { get; set; }
        public class GetByIdBookingQueryHandler : IRequestHandler<GetByIdBookingQuery, GetBookingDto>
        {
            private readonly IAppartmentReadRepository _appartmentReadRepository;
            private readonly IBookingReadRepository _bookingReadRepository;
            private readonly IUserReadRepository _userReadRepository;

            public GetByIdBookingQueryHandler(IAppartmentReadRepository appartmentReadRepository, IBookingReadRepository bookingReadRepository, IUserReadRepository userReadRepository)
            {
                _appartmentReadRepository = appartmentReadRepository;
                _bookingReadRepository = bookingReadRepository;
                _userReadRepository = userReadRepository;
            }

            public async Task<GetBookingDto> Handle(GetByIdBookingQuery request, CancellationToken cancellationToken)
            {
                GetBookingDto result = null;
                var booking = await _bookingReadRepository.GetByIdAsync(request.Id);

                if (booking != null)
                {
                    result = booking.Adapt<GetBookingDto>();
                    result.FinishAt = (Convert.ToDateTime(booking.StartsAt).AddDays((double)booking.BookedFor)).ToString("yyyy-MM-ddTHH:mm:ss.fffZ");
                    var user = await _userReadRepository.GetByIdAsync((int)booking.UserId);
                    if (user != null) user.Adapt(result.users);
                    var appartment = await _appartmentReadRepository.GetByIdAsync((int)booking.ApartmentId);
                    if (appartment != null) appartment.Adapt(result.appartments);
                }
                return result;
            }
        }
    }
}
