using MonitoringService.Domain.Model.Aggregates;
using MonitoringService.Domain.Model.Commands.TypeRoom;

namespace MonitoringService.Domain.Model.Entities
{
    public class TypeRoom
    {
        public int Id { get; set; }
        public int? HotelsId { get; set; }
        public string Description { get; set; } = null!;
        public decimal Price { get; set; }
    
        public virtual ICollection<Room> Rooms { get; set; } = [];

        public TypeRoom()
        {
            this.HotelsId = 0;
            this.Description = string.Empty;
            this.Price = 0;
        }
        public TypeRoom
            (int hotelId, string description, decimal price)
        {
            this.HotelsId = hotelId;
            this.Description = description;
            this.Price = price;
        }
        public TypeRoom
            (CreateTypeRoomCommand command)
        {
            this.HotelsId = command.HotelId;
            this.Description = command.Description;
            this.Price = command.Price;
        }
    }
}