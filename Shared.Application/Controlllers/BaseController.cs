namespace Shared.Application.Controlllers;

public class BaseController< TViewModel> : ControllerBase, IBaseController<TViewModel>
     where TViewModel : class
{
    private readonly IUnitOfWork<TViewModel> _unitOfWork;

    public BaseController(IUnitOfWork<TViewModel> unitOfWork)
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
    public IActionResult Delete([FromBody] TViewModel viewModel)
    {
        try
        {
            _unitOfWork.Delete(viewModel);
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
