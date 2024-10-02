namespace Shared.Application;
public interface IUnitOfWork<TEntity , TViewModel>
    where TEntity : class
{
    Task Create(TViewModel viewModel);

    Task<IEnumerable<TViewModel>> ReadAll();
    Task<TViewModel?> ReadById(int id);

    Task  Update(TViewModel viewModel);

    Task Delete(TViewModel viewModel);

}