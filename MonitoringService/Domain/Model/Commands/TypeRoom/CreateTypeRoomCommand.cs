namespace MonitoringService.Domain.Model.Commands.TypeRoom
{
    public record CreateTypeRoomCommand
        (int HotelId, string Description, decimal Price);
}