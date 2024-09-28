namespace Shared;
public interface IUnitOfWork<TEntity>
    where TEntity : class
{
    Task Create(TEntity student);

    Task<IEnumerable<TEntity>> ReadAll();
    Task<TEntity?> ReadById(int id);

    Task Update(TEntity entity);

    Task Delete(TEntity student);

}