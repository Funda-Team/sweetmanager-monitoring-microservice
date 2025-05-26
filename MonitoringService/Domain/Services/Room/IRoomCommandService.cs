using MonitoringService.Domain.Model.Commands.Room;

namespace MonitoringService.Domain.Services.Room
{
    public interface IRoomCommandService
    {
        Task<bool> Handle
            (CreateRoomCommand command);

        Task<bool> Handle
            (UpdateRoomStateCommand command);
    }
}