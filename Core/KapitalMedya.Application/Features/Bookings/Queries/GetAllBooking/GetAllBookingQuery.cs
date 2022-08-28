using KapitalMedya.Application.Features.Bookings.Dtos;
using KapitalMedya.Application.Repositories.Appartments;
using KapitalMedya.Application.Repositories.Bookings;
using KapitalMedya.Application.Repositories.Users;
using KapitalMedya.Application.RequestParameter;
using Mapster;
using MediatR;

namespace KapitalMedya.Application.Features.Bookings.Queries.GetAllBooking
{
    public class GetAllBookingQuery : IRequest<GetAllBookingListDto>
    {
        public PaginationEntity PaginationEntity { get; set; }
        public class GetAllBookingQueryHandler : IRequestHandler<GetAllBookingQuery, GetAllBookingListDto>
        {
            private readonly IAppartmentReadRepository _appartmentReadRepository;
            private readonly IBookingReadRepository _bookingReadRepository;
            private readonly IUserReadRepository _userReadRepository;

            public GetAllBookingQueryHandler(IAppartmentReadRepository appartmentReadRepository, IBookingReadRepository bookingReadRepository, IUserReadRepository userReadRepository)
            {
                _appartmentReadRepository = appartmentReadRepository;
                _bookingReadRepository = bookingReadRepository;
                _userReadRepository = userReadRepository;
            }

            public async Task<GetAllBookingListDto> Handle(GetAllBookingQuery request, CancellationToken cancellationToken)
            {

                var bookingList = _bookingReadRepository.GetAll().Skip((request.PaginationEntity.PageNumber - 1) * request.PaginationEntity.PageSize).Take(request.PaginationEntity.PageSize).ProjectToType<GetBookingDto>().ToList();

                if (bookingList.Count > 0)
                {
                    foreach (var booking in bookingList)
                    {
                        booking.FinishAt = (Convert.ToDateTime(booking.StartsAt).AddDays((double)booking.BookedFor)).ToString("yyyy-MM-ddTHH:mm:ss.fffZ");
                        var user = await _userReadRepository.GetByIdAsync((int)booking.UserId);
                        if (user != null) user.Adapt(booking.users);
                        var appartment = await _appartmentReadRepository.GetByIdAsync((int)booking.ApartmentId);
                        if (appartment != null) appartment.Adapt(booking.appartments);
                    }
                }
                return new()
                {
                    bookings = bookingList
                };
            }
        }
    }
}
