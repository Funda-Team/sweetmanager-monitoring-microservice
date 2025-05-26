using MonitoringService.Domain.Model.Commands.Booking;
using MonitoringService.Domain.Model.ValueObjects.Booking;
using MonitoringService.Interfaces.REST.Resources.Booking;

namespace MonitoringService.Interfaces.REST.Transform.Booking
{
    public class CreateBookingCommandFromResourceAssembler
    {
        public static CreateBookingCommand ToCommandFromResource
            (CreateBookingResource resource)
        {
            var startDate = DateTime.Parse(resource.StartDate);

            var finalDate = DateTime.Parse(resource.FinalDate);
            
            return new(resource.PaymentCustomerId, resource.RoomId,
                resource.Description, startDate, finalDate,
                resource.PriceRoom, resource.NightCount, EBookingState.RESERVADO);
        }
    }
}