using MonitoringService.Domain.Model.Commands.TypeRoom;
using MonitoringService.Domain.Repositories;
using MonitoringService.Domain.Services.TypeRoom;
using MonitoringService.Shared.Domain.Repositories;

namespace MonitoringService.Application.Internal.CommandServices
{
    public class TypeRoomCommandService
        (ITypeRoomRepository typeRoomRepository,
        IUnitOfWork unitOfWork) :
        ITypeRoomCommandService
    {
        public async Task<bool> Handle
            (CreateTypeRoomCommand command)
        {
            try
            {
                await typeRoomRepository
                    .AddAsync(new(command));

                await unitOfWork.CommitAsync();

                return true;
            }
            catch (Exception) { return false; }
        }
    }
}