namespace Shared.Application.Controlllers;
public interface IBaseController<TViewModel>
                 where TViewModel : class
{
    Task<IActionResult> Post([FromBody] TViewModel viewModel);

    Task<IActionResult> GetAllAsync();
    Task<IActionResult> GetByIdAsync(int id);

    Task<IActionResult> Put([FromBody] TViewModel viewModel);

    IActionResult Delete([FromBody] TViewModel viewModel);
}
