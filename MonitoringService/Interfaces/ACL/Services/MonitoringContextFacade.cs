using MonitoringService.Domain.Model.Queries.Booking;
using MonitoringService.Domain.Model.Queries.Room;
using MonitoringService.Domain.Services.Booking;
using MonitoringService.Domain.Services.Room;

namespace MonitoringService.Interfaces.ACL.Services
{
    public class MonitoringContextFacade
        (IBookingQueryService bookingQueryService,
        IRoomQueryService roomQueryService) :
        IMonitoringContextFacade
    {
        public async Task<bool> ExistsBookingById(int id) =>
            await bookingQueryService.Handle
            (new GetBookingByIdQuery(id)) != null;

        public async Task<bool> ExistsRoomById(int id) =>
            await roomQueryService.Handle
            (new GetRoomByIdQuery(id)) != null;

        public async Task<int> GetRoomsCount(int hotelId)
        {
            var rooms = await roomQueryService.Handle(new GetAllRoomsQuery(hotelId));

            return rooms.Count();
        }
    }
}