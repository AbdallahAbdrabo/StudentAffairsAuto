namespace Shared.Application;

public class Repository<TEntity> : IRepository<TEntity>
    where TEntity : class
{
    private readonly ApplicationDbContext _dbContext;
    private readonly DbSet<TEntity> _dbSet;

    public Repository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
        _dbSet = _dbContext.Set<TEntity>();
    }

    public async Task<TEntity> AddEntity(TEntity tEntity)
    {
        if (tEntity is null) throw new ArgumentNullException(nameof(tEntity));

        TEntity? newEntity = (await _dbSet.AddAsync(tEntity)).Entity;

        return newEntity;

    }

    public async Task<IEnumerable<TEntity>> GetEtities()
    {
        var Entitylist = await _dbSet.ToListAsync();
        return Entitylist;
    }
    public async Task<TEntity?> GetGetEntityById(int tEntityId)
    {
        TEntity? tEntity = await _dbSet.FindAsync(tEntityId);
        return tEntity;
    }

    public TEntity UpdateEntity(TEntity tEntity)
    {
        if (tEntity is null) throw new ArgumentNullException(nameof(tEntity));

        TEntity? newEntity = _dbSet.Update(tEntity).Entity;

        return newEntity;
    }

    public TEntity DeleteEntity(TEntity tEntity)
    {
        if (tEntity is null) throw new ArgumentNullException(nameof(tEntity));

        TEntity? deletedEntity = _dbSet.Remove(tEntity).Entity;

        return deletedEntity;
    }
}
