using MonitoringService.Domain.Model.Aggregates;
using MonitoringService.Domain.Model.Queries.Room;
using MonitoringService.Domain.Repositories;
using MonitoringService.Domain.Services.Room;

namespace MonitoringService.Application.Internal.QueryServices
{
    public class RoomQueryService
        (IRoomRepository roomRepository) :
        IRoomQueryService
    {
        public async Task<IEnumerable<Room>> Handle
            (GetAllRoomsQuery query) =>
            await roomRepository.FindAllByHotelId(query.HotelId);

        public async Task<Room?> Handle
            (GetRoomByIdQuery query) =>
            await roomRepository
            .FindByIdAsync(query.Id);

        public async Task<IEnumerable<Room>> Handle
            (GetRoomsByTypeRoomIdQuery query) =>
            await roomRepository.FindByTypeRoomIdAsync
            (query.TypeRoomId);
    }
}