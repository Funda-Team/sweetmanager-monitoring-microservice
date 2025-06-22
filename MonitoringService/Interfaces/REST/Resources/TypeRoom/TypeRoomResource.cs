namespace MonitoringService.Interfaces.REST.Resources.TypeRoom
{
    public record TypeRoomResource
        (int Id, int HotelId, string Description,
        decimal Price);
}