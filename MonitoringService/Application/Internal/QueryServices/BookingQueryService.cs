using MonitoringService.Domain.Model.Aggregates;
using MonitoringService.Domain.Model.Queries.Booking;
using MonitoringService.Domain.Repositories;
using MonitoringService.Domain.Services.Booking;

namespace MonitoringService.Application.Internal.QueryServices
{
    public class BookingQueryService
        (IBookingRepository bookingRepository) :
        IBookingQueryService
    {
        public async Task<IEnumerable<Booking>> Handle
            (GetAllBookingsQuery query) =>
            await bookingRepository.FindAllByHotelIdAsync(query.HotelId);

        public async Task<Booking?> Handle
            (GetBookingByIdQuery query) =>
            await bookingRepository
            .FindByIdAsync(query.Id);
    }
}