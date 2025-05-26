using MonitoringService.Domain.Model.Queries.Booking;

namespace MonitoringService.Domain.Services.Booking
{
    public interface IBookingQueryService
    {
        Task<IEnumerable<Model.Aggregates.Booking>> Handle
            (GetAllBookingsQuery query);

        Task<Model.Aggregates.Booking?> Handle
            (GetBookingByIdQuery query);
    }
}