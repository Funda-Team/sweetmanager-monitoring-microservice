using MonitoringService.Domain.Model.Commands.Booking;

namespace MonitoringService.Domain.Services.Booking
{
    public interface IBookingCommandService
    {
        Task<bool> Handle
            (CreateBookingCommand command);

        Task<bool> Handle
            (UpdateBookingStateCommand command);
    }
}