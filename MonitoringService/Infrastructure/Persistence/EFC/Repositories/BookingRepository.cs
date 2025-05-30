﻿using Microsoft.EntityFrameworkCore;
using MonitoringService.Domain.Model.Aggregates;
using MonitoringService.Domain.Model.ValueObjects.Booking;
using MonitoringService.Domain.Repositories;
using MonitoringService.Shared.Infrastructure.Persistence.EFC.Configuration;
using MonitoringService.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace MonitoringService.Infrastructure.Persistence.EFC.Repositories
{
    public class BookingRepository
        (MonitoringContext context) :
        BaseRepository<Booking>(context),
        IBookingRepository
    {
        public async Task<bool> UpdateBookingStateAsync(int id, EBookingState bookingState) =>
            await Context.Set<Booking>().Where(b => b.Id == id)
            .ExecuteUpdateAsync(b => b
            .SetProperty(u => u.State, bookingState.ToString())) > 0;

        public async Task<IEnumerable<Booking>> FindAllByHotelIdAsync(int hotelId)
        {
            Task<IEnumerable<Booking>> queryAsync = new(() => (
                from bk in Context.Set<Booking>().ToList()
                join rm in Context.Set<Room>().ToList() on bk.RoomsId equals rm.Id
                where rm.HotelsId.Equals(hotelId)
                select bk
            ).ToList());
            
            queryAsync.Start();

            var result = await queryAsync;

            return result;
        }
    }
}