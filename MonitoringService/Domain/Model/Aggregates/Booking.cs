using MonitoringService.Domain.Model.Commands.Booking;
using MonitoringService.Domain.Model.ValueObjects.Booking;

namespace MonitoringService.Domain.Model.Aggregates
{
    public class Booking
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

        public virtual Room Room { get; set; } = null!;

        public Booking()
        {
            this.RoomsId = 0;
            this.Description = string.Empty;
            this.PriceRoom = 0;
            this.NightCount = 0;
            this.Amount = 0;
            this.State = string.Empty;
        }
        public Booking
            (int roomId, string description, DateTime startDate,
            DateTime finalDate, decimal priceRoom,
            int nightCount, EBookingState bookingState)
        {
            this.RoomsId = roomId;
            this.Description = description;
            this.StartDate = startDate;
            this.FinalDate = finalDate;
            this.PriceRoom = priceRoom;
            this.NightCount = nightCount;
            this.Amount = priceRoom * nightCount;
            this.State = bookingState.ToString();
        }
        public Booking
            (CreateBookingCommand command)
        {
            this.RoomsId = command.RoomId;
            this.Description = command.Description;
            this.StartDate = command.StartDate;
            this.FinalDate = command.FinalDate;
            this.PriceRoom = command.PriceRoom;
            this.NightCount = command.NightCount;
            this.Amount = command.PriceRoom * NightCount;
            this.State = command.BookingState.ToString();
        }
        public Booking
            (UpdateBookingStateCommand command)
        {
            this.Id = command.Id;
            this.State = command.BookingState.ToString();
        }
    }
}