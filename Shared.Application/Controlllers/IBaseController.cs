namespace Shared.Application.Controlllers;
public interface IBaseController<TEntity, TViewModel>
                 where TViewModel : class
{
    Task<IActionResult> Post([FromBody] TViewModel viewModel);

    Task<IActionResult> GetAllAsync();
    Task<IActionResult> GetByIdAsync(int id);

    Task<IActionResult> Put([FromBody] TViewModel viewModel);

    Task<IActionResult> Delete([FromBody] TViewModel viewModel);
}
