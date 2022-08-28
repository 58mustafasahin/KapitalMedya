using KapitalMedya.Application.Features.Bookings.Dtos;
using KapitalMedya.Application.Repositories.Bookings;
using MediatR;

namespace KapitalMedya.Application.Features.Bookings.Commands.RemoveBooking
{
    public class RemoveBookingCommand : IRequest<RemovedBookingDto>
    {
        public int Id { get; set; }

        public class RemoveBookingCommandHandler : IRequestHandler<RemoveBookingCommand, RemovedBookingDto>
        {
            private readonly IBookingWriteRepository _bookingWriteRepository;

            public RemoveBookingCommandHandler(IBookingWriteRepository bookingWriteRepository)
            {
                _bookingWriteRepository = bookingWriteRepository;
            }

            public async Task<RemovedBookingDto> Handle(RemoveBookingCommand request, CancellationToken cancellationToken)
            {
                var booking = _bookingWriteRepository.Table.Where(p => p.Confirmed == 0 && p.Id == request.Id).FirstOrDefault();
                if (booking is not null) await _bookingWriteRepository.RemoveAsync((int)booking.Id);
                var result = await _bookingWriteRepository.SaveAsync();
                return result > 0 ? new RemovedBookingDto() { IsSucceed = true, Message = "Silme İşlemi Başarılı" } : new RemovedBookingDto() { IsSucceed = false, Message = "Silme İşlemi Başarısız" };
            }
        }
    }
}
