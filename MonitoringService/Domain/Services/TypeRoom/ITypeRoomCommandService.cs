using MonitoringService.Domain.Model.Commands.TypeRoom;

namespace MonitoringService.Domain.Services.TypeRoom
{
    public interface ITypeRoomCommandService
    {
        Task<bool> Handle
            (CreateTypeRoomCommand command);
    }
}