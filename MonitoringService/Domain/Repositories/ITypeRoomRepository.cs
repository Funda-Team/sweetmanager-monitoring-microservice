using MonitoringService.Domain.Model.Entities;
using MonitoringService.Shared.Domain.Repositories;

namespace MonitoringService.Domain.Repositories
{
    public interface ITypeRoomRepository :
        IBaseRepository<TypeRoom>
    {
        Task<IEnumerable<TypeRoom>> FindAllByHotelId(int hotelId);
    }
}