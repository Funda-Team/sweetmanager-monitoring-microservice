﻿using MonitoringService.Domain.Model.Queries.Room;

namespace MonitoringService.Domain.Services.Room
{
    public interface IRoomQueryService
    {
        Task<IEnumerable<Model.Aggregates.Room>> Handle
            (GetAllRoomsQuery query);

        Task<Model.Aggregates.Room?> Handle
            (GetRoomByIdQuery query);

        Task<IEnumerable<Model.Aggregates.Room>> Handle
            (GetRoomsByTypeRoomIdQuery query); 
    }
}