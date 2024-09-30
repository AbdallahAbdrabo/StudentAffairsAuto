namespace Shared.Application.UnitOfWork;

public class UnitOfWork<TEntity , TViewModel> : IUnitOfWork<TEntity , TViewModel >
    where TEntity : class where TViewModel : class
{
    private readonly ApplicationDbContext _context;
    private readonly IRepository<TEntity> _repository;
    private readonly IMapper _mapper;

    public UnitOfWork(ApplicationDbContext context
        , IRepository<TEntity> repository, IMapper mapper)
    {
        _context = context;
        _repository = repository;
        _mapper = mapper;
    }

    public async Task Create(TViewModel viewModel)
    {
        using (IDbContextTransaction transaction = _context.Database.BeginTransaction())
        {
            try
            {
                TEntity entity = _mapper.Map<TEntity>(viewModel);
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

    public async Task<IEnumerable<TViewModel>> ReadAll()
    {
        IEnumerable<TEntity>? students = (await _repository.GetEtities()).ToList();
        IEnumerable<TViewModel>? viewModels = _mapper.Map<IEnumerable<TViewModel>>(students);
        return viewModels ;
    }
    public async Task<TViewModel?> ReadById(int id)
    {
        TEntity? entity = await _repository.GetGetEntityById(id);
        TViewModel viewModel = _mapper.Map<TViewModel>(entity);
        return viewModel;
    }


    public async Task Update(TViewModel viewModel)
    {
        using (IDbContextTransaction transaction = _context.Database.BeginTransaction())
        {
            try
            {
                TEntity entity = _mapper.Map<TEntity>(viewModel);
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

    public async Task Delete(TViewModel viewModel)
    {
        TEntity entity = _mapper.Map<TEntity>(viewModel);
        var delete = _repository.DeleteEntity(entity);
        await _context.SaveChangesAsync();
      

    }


    public void Dispose()
    {
        _context.Dispose();
    }
}

