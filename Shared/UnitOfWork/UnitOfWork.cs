


namespace Shared;

public class UnitOfWork<TEntity> : IUnitOfWork<TEntity>
    where TEntity : class
{
    private readonly ApplicationDbContext _context;
    private readonly IRepository<TEntity> _repository;

    public UnitOfWork(ApplicationDbContext context, IRepository<TEntity> repository)
    {
        _context = context;
        _repository = repository;
    }

    public async Task Create(TEntity entity)
    {
        using (IDbContextTransaction transaction = _context.Database.BeginTransaction())
        {
            try
            {
                await _repository.AddEntity(entity);
                await _context.SaveChangesAsync();
                transaction.Commit();
            }
            catch (Exception exception)
            {
                transaction.Rollback();
                Console.WriteLine(exception.Message);
            }
        }
    }

    public Task<IEnumerable<TEntity>> ReadAll()
    {
        return _repository.GetEtities();
    }
    public Task<TEntity?> ReadById(int id)
    {
        return _repository.GetGetEntityById(id);
    }


    public async Task Update(TEntity entity)
    {
        using (IDbContextTransaction transaction = _context.Database.BeginTransaction())
        {
            try
            {
                _repository.UpdateEntity(entity);
                await _context.SaveChangesAsync();
                transaction.Commit();
            }
            catch (Exception exception)
            {
                transaction.Rollback();
                Console.WriteLine(exception.Message);
            }
        }
    }

    public async Task Delete(TEntity entity)
    {
        var delete = _repository.DeleteEntity(entity);
        await _context.SaveChangesAsync();

    }


    public void Dispose()
    {
        _context.Dispose();
    }
}

