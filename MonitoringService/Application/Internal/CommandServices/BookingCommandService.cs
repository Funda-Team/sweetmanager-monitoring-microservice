using MonitoringService.Domain.Model.Commands.Booking;
using MonitoringService.Domain.Repositories;
using MonitoringService.Domain.Services.Booking;
using MonitoringService.Shared.Domain.Repositories;

namespace MonitoringService.Application.Internal.CommandServices
{
    public class BookingCommandService
        (IBookingRepository bookingRepository,
        IUnitOfWork unitOfWork) :
        IBookingCommandService
    {
        public async Task<bool> Handle
            (CreateBookingCommand command)
        {
            try
            {
                await bookingRepository
                    .AddAsync(new(command));

                await unitOfWork.CommitAsync();

                return true;
            }
            catch (Exception) { return false; }
        }

        public async Task<bool> Handle
            (UpdateBookingStateCommand command) =>
            await bookingRepository.UpdateBookingStateAsync
            (command.Id, command.BookingState);
    }
}