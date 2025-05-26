using MonitoringService.Domain.Model.Commands.Room;
using MonitoringService.Domain.Model.ValueObjects.Room;
using MonitoringService.Interfaces.REST.Resources.Room;

namespace MonitoringService.Interfaces.REST.Transform.Room
{
    public class CreateRoomCommandFromResourceAssembler
    {
        public static CreateRoomCommand ToCommandFromResource
            (CreateRoomResource resource) =>
            new(resource.TypeRoomId, resource.HotelId,
                ERoomState.LIBRE);
    }
}