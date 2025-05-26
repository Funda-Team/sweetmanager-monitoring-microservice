using MonitoringService.Domain.Model.ValueObjects.Room;

namespace MonitoringService.Domain.Model.Commands.Room
{
    public record UpdateRoomStateCommand
        (int Id, ERoomState RoomState);
}