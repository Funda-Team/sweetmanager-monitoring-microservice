using System;
using System.Collections.Generic;

namespace MonitoringService;

public partial class Booking
{
    public int Id { get; set; }

    public int? PaymentsCustomer { get; set; }

    public int RoomsId { get; set; }

    public string? Description { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? FinalDate { get; set; }

    public decimal? PriceRoom { get; set; }

    public int? NightCount { get; set; }

    public decimal? Amount { get; set; }

    public string? State { get; set; }

    public virtual Room Rooms { get; set; } = null!;
}
