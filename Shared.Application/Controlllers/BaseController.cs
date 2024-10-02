namespace Shared.Application;

public class BaseController<TEntity,TViewModel> : ControllerBase, IBaseController<TEntity ,TViewModel>
     where TViewModel : class
     where TEntity : class
{
    private readonly IUnitOfWork<TEntity,TViewModel> _unitOfWork;

    public BaseController(IUnitOfWork<TEntity, TViewModel> unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    [HttpPost]
    public  async Task<IActionResult> Post([FromBody] TViewModel viewModel)
    {
       
        try
        {
            if (viewModel == null)
                return BadRequest("ViewModel can not be null");
         
            await _unitOfWork.Create(viewModel);
            return Ok();
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Internal server error: " + ex.Message);
        }


    }
    [HttpDelete]
    public async Task<IActionResult> Delete([FromBody] TViewModel viewModel)
    {
        try
        {
           await _unitOfWork.Delete(viewModel);
            return Ok();
        }
        catch (Exception ex)
        {
            
            return StatusCode(500, "Internal server error: " + ex.Message);
        }
    }
    [HttpGet]
    public  async Task<IActionResult> GetAllAsync()
    {
      List<TViewModel>? listOfEntity = (await _unitOfWork.ReadAll()).ToList();
        return Ok(listOfEntity);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
       TViewModel? viewModel = await _unitOfWork.ReadById(id);
        return Ok(viewModel);
    }

    [HttpPut]
    public async Task<IActionResult> Put([FromBody] TViewModel viewModel)
    {
        try
        {
            await _unitOfWork.Update(viewModel);
            return Ok();
        }
        catch (Exception ex)
        {
            
            return StatusCode(500, "Internal server error: " + ex.Message);
        }
    }
}
