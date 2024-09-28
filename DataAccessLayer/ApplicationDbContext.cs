

namespace DataAccessLayer;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext
{

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        
        IConfigurationRoot? config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();
        string? connectionString = config
                                  .GetConnectionString("DefaultConnection");

        optionsBuilder.UseSqlServer(connectionString);
        base.OnConfiguring(optionsBuilder);
    }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        
        builder.ApplyConfigurationsFromAssembly(typeof(StudentEntityConfiguration).Assembly);
        base.OnModelCreating(builder);
    }
}
