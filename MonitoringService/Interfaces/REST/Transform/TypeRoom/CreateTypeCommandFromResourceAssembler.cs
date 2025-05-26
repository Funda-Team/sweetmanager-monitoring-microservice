using MonitoringService.Domain.Model.Commands.TypeRoom;
using MonitoringService.Interfaces.REST.Resources.TypeRoom;

namespace MonitoringService.Interfaces.REST.Transform.TypeRoom
{
    public class CreateTypeCommandFromResourceAssembler
    {
        public static CreateTypeRoomCommand ToCommandFromResource
            (CreateTypeRoomResource resource) =>
            new(resource.Description, resource.Price);
    }
}