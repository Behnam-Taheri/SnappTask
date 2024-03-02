using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using SnappFood.Framework.Core.Abstractions;

namespace SnappFood.Persistence.EF
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SnappContext context;
        private IDbContextTransaction transaction;
        public UnitOfWork(SnappContext context)
        {
            this.context = context;
        }

        public async Task BeginAsync(CancellationToken cancellationToken = default)
        {
            transaction = await context.Database.BeginTransactionAsync(cancellationToken);
        }

        public async Task CommitAsync(CancellationToken cancellationToken = default) => await transaction.CommitAsync(cancellationToken);

        public async Task RolBackAsync(CancellationToken cancellationToken = default) => await transaction.RollbackAsync(cancellationToken);

    }

  
}
