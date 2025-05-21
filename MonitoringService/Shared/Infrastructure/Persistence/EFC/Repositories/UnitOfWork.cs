using IamService.Shared.Domain.Repositories;

namespace MonitoringService.Shared.Infrastructure.Persistence.EFC.Repositories
{
    public class UnitOfWork(MonitoringContext context) : IUnitOfWork
    {
        public async Task CommitAsync() => await context.SaveChangesAsync();
    }
}