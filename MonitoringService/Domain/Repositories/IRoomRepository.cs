using MonitoringService.Domain.Model.Aggregates;
using MonitoringService.Domain.Model.ValueObjects.Room;
using MonitoringService.Shared.Domain.Repositories;

namespace MonitoringService.Domain.Repositories
{
    public interface IRoomRepository :
        IBaseRepository<Room>
    {
        Task<bool> UpdateRoomStateAsync(int id, ERoomState roomState);

        Task<IEnumerable<Room>> FindByTypeRoomIdAsync(int typeRoomId);

        Task<IEnumerable<Room>> FindAllByHotelId(int hotelId);
    }
}