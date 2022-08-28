using KapitalMedya.Application.Features.Bookings.Dtos;
using KapitalMedya.Application.Repositories.Bookings;
using KapitalMedya.Domain.Entities;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KapitalMedya.Application.Features.Bookings.Commands.CreateBooking
{
    public class CreateBookingCommand : IRequest<CreatedBookingDto>
    {
        public int? UserId { get; set; }
        public string? StartsAt { get; set; }
        public string? BookedAt { get; set; }
        public int? BookedFor { get; set; }
        public int? ApartmentId { get; set; }
        public int? Confirmed { get; set; }

        public class CreateBookingCommandHandler : IRequestHandler<CreateBookingCommand, CreatedBookingDto>
        {
            private readonly IBookingReadRepository _bookingReadRepository;
            private readonly IBookingWriteRepository _bookingWriteRepository;

            public CreateBookingCommandHandler(IBookingReadRepository bookingReadRepository, IBookingWriteRepository bookingWriteRepository)
            {
                _bookingReadRepository = bookingReadRepository;
                _bookingWriteRepository = bookingWriteRepository;
            }

            public async Task<CreatedBookingDto> Handle(CreateBookingCommand request, CancellationToken cancellationToken)
            {
                var lastBooking = await _bookingReadRepository.Table.OrderByDescending(p => p.Id).FirstOrDefaultAsync();
                var newBooking = request.Adapt<Booking>();
                newBooking.Id = lastBooking.Id + 1;
                await _bookingWriteRepository.AddAsync(newBooking);
                var result = await _bookingWriteRepository.SaveAsync();
                return result > 0 ? newBooking.Adapt<CreatedBookingDto>() : null;
            }
        }
    }
}
