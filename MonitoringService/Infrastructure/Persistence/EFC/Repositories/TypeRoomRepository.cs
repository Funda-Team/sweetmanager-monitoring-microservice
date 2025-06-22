using Microsoft.EntityFrameworkCore;
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
            => await Context.Set<TypeRoom>().Where(t => t.HotelsId == hotelId).ToListAsync();
    }
}