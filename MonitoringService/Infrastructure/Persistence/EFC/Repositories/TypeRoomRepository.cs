using MonitoringService.Domain.Model.Aggregates;
using MonitoringService.Domain.Model.Entities;
using MonitoringService.Domain.Repositories;
using MonitoringService.Shared.Infrastructure.Persistence.EFC.Configuration;
using MonitoringService.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace MonitoringService.Infrastructure.Persistence.EFC.Repositories
{
    public class TypeRoomRepository
        (MonitoringContext context) :
        BaseRepository<TypeRoom>(context),
        ITypeRoomRepository
    {
        public async Task<IEnumerable<TypeRoom>> FindAllByHotelId(int hotelId)
        {
            Task<IEnumerable<TypeRoom>> queryAsync = new (() => (
                from tr in Context.Set<TypeRoom>().ToList()
                join ro in Context.Set<Room>().ToList() on tr.Id equals ro.TypesRoomsId
                where ro.HotelsId.Equals(hotelId)
                select tr
            ).ToList());

            queryAsync.Start();

            var result = await queryAsync;

            return result;
        }
    }
}