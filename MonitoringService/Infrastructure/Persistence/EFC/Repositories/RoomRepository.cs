using Microsoft.EntityFrameworkCore;
using MonitoringService.Domain.Model.Aggregates;
using MonitoringService.Domain.Model.ValueObjects.Room;
using MonitoringService.Domain.Repositories;
using MonitoringService.Shared.Infrastructure.Persistence.EFC.Configuration;
using MonitoringService.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace MonitoringService.Infrastructure.Persistence.EFC.Repositories
{
    public class RoomRepository
        (MonitoringContext context) :
        BaseRepository<Room>(context),
        IRoomRepository
    {
        public async Task<bool> UpdateRoomStateAsync
            (int id, ERoomState roomState) =>
            await Context.Set<Room>().Where(r => r.Id == id)
            .ExecuteUpdateAsync(r => r
            .SetProperty(u => u.State, roomState.ToString())) > 0;

        public async Task<IEnumerable<Room>> FindByTypeRoomIdAsync
            (int typeRoomId) => await Context.Set<Room>()
            .Where(r => r.TypesRoomsId == typeRoomId)
            .ToListAsync();

        public async Task<IEnumerable<Room>> FindAllByHotelId(int hotelId)
        {
            Task<IEnumerable<Room>> queryAsync = new(() => (
                from rm in Context.Set<Room>().ToList()
                where rm.HotelsId.Equals(hotelId)
                select rm
            ).ToList());

            queryAsync.Start();
            
            var result = await queryAsync;

            return result;
        }
    }
}