using MonitoringService.Domain.Model.Queries.TypeRoom;

namespace MonitoringService.Domain.Services.TypeRoom
{
    public interface ITypeRoomQueryService
    {
        Task<IEnumerable<Model.Entities.TypeRoom>> Handle
            (GetAllTypesRoomsQuery query);

        Task<Model.Entities.TypeRoom?> Handle
            (GetTypeRoomByIdQuery query);
    }
}