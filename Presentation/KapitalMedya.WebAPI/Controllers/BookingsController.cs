using KapitalMedya.Application.Features.Bookings.Commands.CreateBooking;
using KapitalMedya.Application.Features.Bookings.Commands.RemoveBooking;
using KapitalMedya.Application.Features.Bookings.Commands.UpdateBooking;
using KapitalMedya.Application.Features.Bookings.Queries.GetAllBooking;
using KapitalMedya.Application.Features.Bookings.Queries.GetByIdBooking;
using KapitalMedya.Application.Features.Bookings.Queries.GetFilterBooking;
using Microsoft.AspNetCore.Mvc;

namespace KapitalMedya.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingsController : BaseController
    {
        /// <summary>
        ///     Id'ye göre rezervasyon getirir.
        /// </summary>
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdBookingQuery getByIdBookingQuery)
        {
            var result = await Mediator.Send(getByIdBookingQuery);
            return Ok(result);
        }

        /// <summary>
        ///     Filtreye göre rezervasyonları getirir.
        /// </summary>
        [HttpPost("[action]")]
        public async Task<IActionResult> GetFilter(GetFilterBookingQuery getFilterBookingQuery)
        {
            var result = await Mediator.Send(getFilterBookingQuery);
            return Ok(result);
        }

        /// <summary>
        ///     Tüm rezervasyonları getirir.
        /// </summary>
        /// <remarks>
        ///     Sayfalama ile istenilen sayfa ve istelen veri sayısı kadar rezervasyon getirir.
        ///     Eğer bu veriler gönderilmezse başlangıç olarak 1.sayfadaki ilk 10 veri getirilir.
        /// </remarks>
        [HttpPost("[action]")]
        public async Task<IActionResult> GetAll([FromBody] GetAllBookingQuery getAllBookingQuery)
        {
            var result = await Mediator.Send(getAllBookingQuery);
            return Ok(result);
        }

        /// <summary>
        ///     Rezervasyon ekler.
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateBookingCommand createBookingCommand)
        {
            var result = await Mediator.Send(createBookingCommand);
            return Ok(result);
        }

        /// <summary>
        ///     Rezervasyon günceller.
        /// </summary>
        [HttpPut]
        public async Task<IActionResult> Put(UpdateBookingCommand updateBookingCommand)
        {
            var result = await Mediator.Send(updateBookingCommand);
            return Ok(result);
        }

        /// <summary>
        ///     Rezervasyon siler.
        /// </summary>
        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] RemoveBookingCommand removeBookingCommand)
        {
            var result = await Mediator.Send(removeBookingCommand);
            return Ok(result);
        }
    }
}
