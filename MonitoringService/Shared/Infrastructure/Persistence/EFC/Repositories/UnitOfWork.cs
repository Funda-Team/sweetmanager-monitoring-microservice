using IamService.Shared.Domain.Repositories;
using MonitoringService.Shared.Infrastructure.Persistence.EFC.Configuration;

namespace MonitoringService.Shared.Infrastructure.Persistence.EFC.Repositories
{
    public class UnitOfWork(MonitoringContext context) : IUnitOfWork
    {
        public async Task CommitAsync() => await context.SaveChangesAsync();
    }
}