using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using MonitoringService.Domain.Services.Booking;
using MonitoringService.Domain.Model.Queries.Booking;
using MonitoringService.Interfaces.REST.Resources.Booking;
using MonitoringService.Interfaces.REST.Transform.Booking;

namespace MonitoringService.Interfaces.REST
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    public class BookingsController
        (IBookingCommandService bookingCommandService,
        IBookingQueryService bookingQueryService) : ControllerBase
    {
        [HttpPost("create-booking")]
        public async Task<IActionResult> CreateBooking([FromBody] CreateBookingResource resource)
        {
            var result = await bookingCommandService
                .Handle(CreateBookingCommandFromResourceAssembler
                .ToCommandFromResource(resource));

            if (result is false)
                return BadRequest();

            return Ok(result);
        }

        [HttpPut("update-booking-state")]
        public async Task<IActionResult> UpdateBookingState([FromBody] UpdateBookingStateResource resource)
        {
            var result = await bookingCommandService
                .Handle(UpdateBookingCommandFromResourceAssembler
                .ToCommandFromResource(resource));

            if (result is false)
                return BadRequest();

            return Ok(result);
        }

        [HttpGet("get-all-bookings/{hotelld:int}")]
        public async Task<IActionResult> AllBookings(int hotelld)
        {
            var bookings = await bookingQueryService
                .Handle(new GetAllBookingsQuery(hotelld));

            var bookingsResource = bookings.Select
                (BookingResourceFromEntityAssembler
                .ToResourceFromEntity);

            return Ok(bookingsResource);
        }

        [HttpGet("get-booking-id")]
        public async Task<IActionResult> BookingById([FromQuery] int id)
        {
            var booking = await bookingQueryService
                .Handle(new GetBookingByIdQuery(id));

            if (booking is null)
                return BadRequest();

            var bookingResource = BookingResourceFromEntityAssembler
                .ToResourceFromEntity(booking);

            return Ok(bookingResource);
        }
    }
}