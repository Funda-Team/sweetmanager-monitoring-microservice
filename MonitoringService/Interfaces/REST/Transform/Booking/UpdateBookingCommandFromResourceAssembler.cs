using MonitoringService.Domain.Model.Commands.Booking;
using MonitoringService.Domain.Model.ValueObjects.Booking;
using MonitoringService.Interfaces.REST.Resources.Booking;

namespace MonitoringService.Interfaces.REST.Transform.Booking
{
    public class UpdateBookingCommandFromResourceAssembler
    {
        public static UpdateBookingStateCommand ToCommandFromResource
            (UpdateBookingStateResource resource) =>
            new(resource.Id, Enum.Parse<EBookingState>
                (resource.BookingState));
    }
}