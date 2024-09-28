using Enrollments.Application.Model;

namespace DataAccessLayer;

public class EnrollmentEntittyConfiguration : IEntityTypeConfiguration<Enrollment>
{
    public void Configure(EntityTypeBuilder<Enrollment> builder)
    {
        builder.ToTable("Enrollments");
        builder.HasKey(e => e.EnrollmentId);
      
    }
}
