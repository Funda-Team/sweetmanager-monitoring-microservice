using Microsoft.AspNetCore.Mvc;

namespace MonitoringService.Interfaces.ACL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MonitoringContextFacadeController
        (IMonitoringContextFacade monitoringContextFacade) :
        ControllerBase
    {
        [HttpGet("booking-exists/{id:int}")]
        public async Task<IActionResult> BookingExists(int id)
        {
            bool exists = await monitoringContextFacade.ExistsBookingById(id);

            return Ok(new { bookingId = id, exists });
        }

        [HttpGet("room-exists/{id:int}")]
        public async Task<IActionResult> RoomExists(int id)
        {
            bool exists = await monitoringContextFacade.ExistsRoomById(id);

            return Ok(new { roomId = id, exists });
        }

        [HttpGet("rooms-count/{hotelId:int}")]
        public async Task<IActionResult> GetRoomsCount(int hotelId)
        {
            int count = await monitoringContextFacade.GetRoomsCount(hotelId);

            return Ok(new { hotelId, roomCount = count });
        }
    }
}