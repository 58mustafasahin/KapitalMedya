using FluentValidation;
using KapitalMedya.Application.Features.Bookings.Commands.CreateBooking;

namespace KapitalMedya.Application.Validators.Bookings
{
    public class AddBookingValidator : AbstractValidator<CreateBookingCommand>
    {
        public AddBookingValidator()
        {

        }
    }
}
