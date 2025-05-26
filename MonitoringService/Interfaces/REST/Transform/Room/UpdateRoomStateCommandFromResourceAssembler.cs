using MonitoringService.Domain.Model.Commands.Room;
using MonitoringService.Domain.Model.ValueObjects.Room;
using MonitoringService.Interfaces.REST.Resources.Room;

namespace MonitoringService.Interfaces.REST.Transform.Room
{
    public class UpdateRoomStateCommandFromResourceAssembler
    {
        public static UpdateRoomStateCommand ToCommandFromResource
            (UpdateRoomStateResource resource) =>
            new(resource.Id, Enum.Parse<ERoomState>
                (resource.RoomState));
    }
}