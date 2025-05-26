using MonitoringService.Domain.Model.Aggregates;
using MonitoringService.Domain.Model.ValueObjects.Booking;
using MonitoringService.Shared.Domain.Repositories;

namespace MonitoringService.Domain.Repositories
{
    public interface IBookingRepository :
        IBaseRepository<Booking>
    {
        Task<bool> UpdateBookingStateAsync
            (int id, EBookingState bookingState);

        Task<IEnumerable<Booking>> FindAllByHotelIdAsync(int hotelId);
    }
}