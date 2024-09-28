namespace Shared.Application;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        IConfigurationRoot? config = new ConfigurationBuilder()
           .AddJsonFile("appsettings.json")
           .Build();
        string? connectionString = config
                                  .GetConnectionString("DefaultConnection");

        optionsBuilder.UseSqlServer(
          connectionString,
          b => b.MigrationsAssembly("StudentAffairsAuto"));
     
        base.OnConfiguring(optionsBuilder);
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        foreach (Assembly assemblyReferencedAssembly in AssemblyExtentions.GetReferencedAssemblies(Assembly.GetExecutingAssembly(), "*.Application.dll"))
        {
            try
            {
                modelBuilder.ApplyConfigurationsFromAssembly(assemblyReferencedAssembly);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        base.OnModelCreating(modelBuilder);
    }
}
