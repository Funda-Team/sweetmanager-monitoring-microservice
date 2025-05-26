using MonitoringService.Domain.Model.Commands.Room;
using MonitoringService.Domain.Repositories;
using MonitoringService.Domain.Services.Room;
using MonitoringService.Shared.Domain.Repositories;

namespace MonitoringService.Application.Internal.CommandServices
{
    public class RoomCommandService
        (IRoomRepository roomRepository,
        IUnitOfWork unitOfWork) :
        IRoomCommandService
    {
        public async Task<bool> Handle
            (CreateRoomCommand command)
        {
            try
            {
                await roomRepository
                    .AddAsync(new(command));

                await unitOfWork.CommitAsync();

                return true;
            }
            catch (Exception) { return false; }
        }

        public async Task<bool> Handle
            (UpdateRoomStateCommand command) =>
            await roomRepository.UpdateRoomStateAsync
            (command.Id, command.RoomState);
    }
}