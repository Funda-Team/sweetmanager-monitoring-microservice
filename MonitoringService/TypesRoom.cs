using System;
using System.Collections.Generic;

namespace MonitoringService;

public partial class TypesRoom
{
    public int Id { get; set; }

    public string Descript { get; set; } = null!;

    public decimal Price { get; set; }

    public virtual ICollection<Room> Rooms { get; set; } = new List<Room>();
}
