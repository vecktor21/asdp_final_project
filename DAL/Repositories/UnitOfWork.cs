using Microsoft.EntityFrameworkCore.Storage;

namespace ASDP.FinalProject.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AdspContext _context;
        private readonly IServiceProvider _serviceProvider;
        private IDbContextTransaction? _transaction;

        public UnitOfWork(AdspContext context, IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _context = context;
        }

        public bool BeginTransaction()
        {
            if (_transaction is not null) return false;
            _transaction = _context.Database.BeginTransaction();
            return true;
        }

        public bool CommitTransaction()
        {
            if (_transaction is null) return false;
            _transaction.Commit();
            _transaction = null;
            return true;
        }

        public void Dispose()
        {
            CommitTransaction();
            _context.Dispose();
        }

        public bool IsTransactionOpen()
        {
            return _transaction is not null;
        }

        public bool RollbackTransaction()
        {
            if (_transaction is null) return false;
            _transaction.Rollback();
            _transaction = null;
            return true;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task SaveChangesAsync(CancellationToken token)
        {
            await _context.SaveChangesAsync(token);
        }

        public T GetRepository<T>() where T : IRepository
        {
            return _serviceProvider.GetRequiredService<T>();
        }

        public AdspContext GetContext()
        {
            return _context;
        }
    }
}
