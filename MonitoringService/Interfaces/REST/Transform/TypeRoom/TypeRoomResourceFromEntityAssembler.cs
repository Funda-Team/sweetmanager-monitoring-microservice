using MonitoringService.Interfaces.REST.Resources.TypeRoom;

namespace MonitoringService.Interfaces.REST.Transform.TypeRoom
{
    public class TypeRoomResourceFromEntityAssembler
    {
        public static TypeRoomResource ToResourceFromEntity
            (Domain.Model.Entities.TypeRoom entity) =>
            new(entity.Id, entity.HotelsId ?? 0,
                entity.Description, entity.Price);
    }
}