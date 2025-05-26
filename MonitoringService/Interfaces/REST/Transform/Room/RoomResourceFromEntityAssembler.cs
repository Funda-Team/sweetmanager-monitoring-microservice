using MonitoringService.Interfaces.REST.Resources.Room;

namespace MonitoringService.Interfaces.REST.Transform.Room
{
    public class RoomResourceFromEntityAssembler
    {
        public static RoomResource ToResourceFromEntity
            (Domain.Model.Aggregates.Room entity) =>
            new(entity.Id, entity.TypesRoomsId, entity.State);
    }
}