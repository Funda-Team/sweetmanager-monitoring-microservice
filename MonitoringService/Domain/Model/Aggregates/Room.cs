using MonitoringService.Domain.Model.Commands.Room;
using MonitoringService.Domain.Model.Entities;
using MonitoringService.Domain.Model.ValueObjects.Room;

namespace MonitoringService.Domain.Model.Aggregates
{
    public class Room
    {
        public int Id { get; set; }
        public int TypesRoomsId { get; set; }
        public int? HotelsId { get; set; }
        public string? State { get; set; }

        public virtual TypeRoom TypesRoom { get; set; } = null!;

        public virtual ICollection<Booking> Bookings { get; set; } = [];

        public Room()
        {
            this.TypesRoomsId = 0;
            this.HotelsId = 0;
            this.State = string.Empty;
        }
        public Room(int typeRoomId, int hotelId, ERoomState roomState)
        {
            this.TypesRoomsId = typeRoomId;
            this.HotelsId = hotelId;
            this.State = roomState.ToString();
        }
        public Room
            (CreateRoomCommand command)
        {
            this.TypesRoomsId = command.TypeRoomId;
            this.HotelsId = command.HotelId;
            this.State = command.RoomState.ToString();
        }
        public Room
            (UpdateRoomStateCommand command)
        {
            this.Id = command.Id;
            this.State = command.RoomState.ToString();
        }
    }
}