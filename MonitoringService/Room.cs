using System;
using System.Collections.Generic;

namespace MonitoringService;

public partial class Room
{
    public int Id { get; set; }

    public int TypesRoomsId { get; set; }

    public int? HotelsId { get; set; }

    public string? State { get; set; }

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    public virtual TypesRoom TypesRooms { get; set; } = null!;
}
