namespace MonitoringService.Interfaces.REST.Resources.TypeRoom
{
    public record CreateTypeRoomResource
        (int HotelId, string Description, decimal Price);
}