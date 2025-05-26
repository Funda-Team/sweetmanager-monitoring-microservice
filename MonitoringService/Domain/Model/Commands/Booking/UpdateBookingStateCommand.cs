using MonitoringService.Domain.Model.ValueObjects.Booking;

namespace MonitoringService.Domain.Model.Commands.Booking
{
    public record UpdateBookingStateCommand
        (int Id, EBookingState BookingState);
}