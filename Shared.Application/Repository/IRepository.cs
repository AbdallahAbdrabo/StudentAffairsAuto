namespace Shared.Application;

public interface IRepository<TEntity>
    where TEntity : class
{

    public Task<TEntity> AddEntity(TEntity tEntity);

    public Task<IEnumerable<TEntity>> GetEtities();
    public Task<TEntity?> GetGetEntityById(int tEntityId);

    public TEntity UpdateEntity(TEntity tEntity);

    public TEntity DeleteEntity(TEntity tEntity);

}
