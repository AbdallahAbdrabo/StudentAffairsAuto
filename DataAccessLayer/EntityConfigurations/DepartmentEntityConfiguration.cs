


using Departments.Application.Model;

namespace DataAccessLayer;

public class DepartmentEntityConfiguration : IEntityTypeConfiguration<Department>
{
    public void Configure(EntityTypeBuilder<Department> builder)
    {
        builder.ToTable("Departments");
        builder.HasKey(d=>d.DepartmentID);
        builder.Property(d=>d.DepartmentName)
            .IsRequired().HasMaxLength(50);

        builder.HasMany(d => d.TeachingStaff)
            .WithOne(f => f.Department)
            .HasForeignKey(f => f.DepartmentId);
        builder.HasMany(d => d.Courses)
            .WithOne(c => c.Department)
            .HasForeignKey(c => c.DepartmentId);
    }
}
