using MonitoringService.Domain.Model.Aggregates;
using MonitoringService.Domain.Model.Commands.TypeRoom;

namespace MonitoringService.Domain.Model.Entities
{
    public class TypeRoom
    {
        public int Id { get; set; }
        public string Description { get; set; } = null!;
        public decimal Price { get; set; }
    
        public virtual ICollection<Room> Rooms { get; set; } = [];

        public TypeRoom()
        {
            this.Description = string.Empty;
            this.Price = 0;
        }
        public TypeRoom
            (string description, decimal price)
        {
            this.Description = description;
            this.Price = price;
        }
        public TypeRoom
            (CreateTypeRoomCommand command)
        {
            this.Description = command.Description;
            this.Price = command.Price;
        }
    }
}