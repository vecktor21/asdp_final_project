using Microsoft.EntityFrameworkCore.Storage;

namespace ASDP.FinalProject.DAL.Repositories
{
    public interface IUnitOfWork
    {
        T GetRepository<T>() where T : IRepository;
        AdspContext GetContext();
        Task SaveChangesAsync();
        Task SaveChangesAsync(CancellationToken token);
        bool BeginTransaction();
        bool CommitTransaction();
        bool RollbackTransaction();
        bool IsTransactionOpen();
    }
}
