using KapitalMedya.Application.Features.Bookings.Dtos;
using KapitalMedya.Application.Repositories.Appartments;
using KapitalMedya.Application.Repositories.Bookings;
using KapitalMedya.Application.Repositories.Users;
using KapitalMedya.Application.RequestParameter;
using Mapster;
using MediatR;

namespace KapitalMedya.Application.Features.Bookings.Queries.GetFilterBooking
{
    public class GetFilterBookingQuery : IRequest<GetAllBookingListDto>
    {
        public GetFilterBookingDto GetFilterBookingDto { get; set; }
        public class GetFilterBookingQueryHandler : IRequestHandler<GetFilterBookingQuery, GetAllBookingListDto>
        {
            private readonly IAppartmentReadRepository _appartmentReadRepository;
            private readonly IBookingReadRepository _bookingReadRepository;
            private readonly IUserReadRepository _userReadRepository;

            public GetFilterBookingQueryHandler(IAppartmentReadRepository appartmentReadRepository, IBookingReadRepository bookingReadRepository, IUserReadRepository userReadRepository)
            {
                _appartmentReadRepository = appartmentReadRepository;
                _bookingReadRepository = bookingReadRepository;
                _userReadRepository = userReadRepository;
            }

            public async Task<GetAllBookingListDto> Handle(GetFilterBookingQuery request, CancellationToken cancellationToken)
            {

                var queryBooking = _bookingReadRepository.Table.AsQueryable();
                if (request.GetFilterBookingDto.Confirmed != null && request.GetFilterBookingDto.Confirmed > 0)
                {
                    queryBooking = queryBooking.Where(p => p.Confirmed == request.GetFilterBookingDto.Confirmed);
                }

                var bookingList = queryBooking.ProjectToType<GetBookingDto>().ToList();

                if (request.GetFilterBookingDto.StartDate != null)
                {
                    bookingList = bookingList.Where(p => Convert.ToDateTime(p.StartsAt).CompareTo(Convert.ToDateTime(request.GetFilterBookingDto.StartDate)) > 0).ToList();
                }
                if (request.GetFilterBookingDto.FinishDate != null)
                {
                    bookingList = bookingList.Where(p => Convert.ToDateTime(p.StartsAt).AddDays((double)p.BookedFor).CompareTo(Convert.ToDateTime(request.GetFilterBookingDto.FinishDate)) < 0).ToList();
                }

                List<GetBookingDto> newBookingList = new List<GetBookingDto>();
                if (bookingList.Count > 0)
                {
                    foreach (var booking in bookingList)
                    {
                        booking.FinishAt = (Convert.ToDateTime(booking.StartsAt).AddDays((double)booking.BookedFor)).ToString("yyyy-MM-ddTHH:mm:ss.fffZ");

                        var user = await _userReadRepository.GetByIdAsync((int)booking.UserId);
                        var appartment = await _appartmentReadRepository.GetByIdAsync((int)booking.ApartmentId);
                        if (user != null)
                        {
                            if (request.GetFilterBookingDto.StartDate != null && request.GetFilterBookingDto.FinishDate != null)
                            {
                                user.Adapt(booking.users);
                                appartment.Adapt(booking.appartments);
                            }
                            if (!string.IsNullOrEmpty(request.GetFilterBookingDto.FirstName))
                            {
                                if (user.FirstName.ToLower().Contains(request.GetFilterBookingDto.FirstName.ToLower()))
                                {
                                    user.Adapt(booking.users);
                                    appartment.Adapt(booking.appartments);
                                }
                                else
                                    continue;
                            }
                            if (!string.IsNullOrEmpty(request.GetFilterBookingDto.LastName))
                            {
                                if (user.LastName.ToLower().Contains(request.GetFilterBookingDto.LastName.ToLower()))
                                {
                                    user.Adapt(booking.users);
                                    appartment.Adapt(booking.appartments);
                                }
                                else
                                    continue;
                            }
                            if (!string.IsNullOrEmpty(request.GetFilterBookingDto.Name))
                            {
                                if (appartment.Name.ToLower().Contains(request.GetFilterBookingDto.Name.ToLower()))
                                {
                                    user.Adapt(booking.users);
                                    appartment.Adapt(booking.appartments);
                                }
                                else
                                    continue;
                            }
                            newBookingList.Add(booking);
                        }
                    }
                }
                newBookingList = newBookingList.Skip((request.GetFilterBookingDto.PaginationEntity.PageNumber - 1) * request.GetFilterBookingDto.PaginationEntity.PageSize).Take(request.GetFilterBookingDto.PaginationEntity.PageSize).ToList();

                return new()
                {
                    bookings = newBookingList
                };
            }
        }
    }
}
