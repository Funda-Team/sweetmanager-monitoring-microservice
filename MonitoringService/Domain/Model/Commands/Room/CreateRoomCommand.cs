using MonitoringService.Domain.Model.ValueObjects.Room;

namespace MonitoringService.Domain.Model.Commands.Room
{
    public record CreateRoomCommand
        (int TypeRoomId, int HotelId,
        ERoomState RoomState);
}