using MonitoringService.Domain.Model.Entities;
using MonitoringService.Domain.Model.Queries.TypeRoom;
using MonitoringService.Domain.Repositories;
using MonitoringService.Domain.Services.TypeRoom;

namespace MonitoringService.Application.Internal.QueryServices
{
    public class TypeRoomQueryService
        (ITypeRoomRepository typeRoomRepository) :
        ITypeRoomQueryService
    {
        public async Task<IEnumerable<TypeRoom>> Handle
            (GetAllTypesRoomsQuery query) =>
            await typeRoomRepository.FindAllByHotelId(query.HotelId);

        public async Task<TypeRoom?> Handle
            (GetTypeRoomByIdQuery query) =>
            await typeRoomRepository
            .FindByIdAsync(query.Id);
    }
}