using KapitalMedya.Application.Features.Bookings.Dtos;
using KapitalMedya.Application.Repositories.Bookings;
using Mapster;
using MediatR;

namespace KapitalMedya.Application.Features.Bookings.Commands.UpdateBooking
{
    public class UpdateBookingCommand : IRequest<UpdatedBookingDto>
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public string? StartsAt { get; set; }
        public string? BookedAt { get; set; }
        public int? BookedFor { get; set; }
        public int? ApartmentId { get; set; }
        public int? Confirmed { get; set; }

        public class UpdateBookingCommandHandler : IRequestHandler<UpdateBookingCommand, UpdatedBookingDto>
        {
            private readonly IBookingReadRepository _bookingReadRepository;
            private readonly IBookingWriteRepository _bookingWriteRepository;

            public UpdateBookingCommandHandler(IBookingReadRepository bookingReadRepository, IBookingWriteRepository bookingWriteRepository)
            {
                _bookingReadRepository = bookingReadRepository;
                _bookingWriteRepository = bookingWriteRepository;
            }

            public async Task<UpdatedBookingDto> Handle(UpdateBookingCommand request, CancellationToken cancellationToken)
            {
                var booking = await _bookingReadRepository.GetByIdAsync(request.Id);
                _bookingWriteRepository.Update(booking);
                request.Adapt(booking);
                var result = await _bookingWriteRepository.SaveAsync();
                return result > 0 ? booking.Adapt<UpdatedBookingDto>() : null;
            }
        }
    }
}
