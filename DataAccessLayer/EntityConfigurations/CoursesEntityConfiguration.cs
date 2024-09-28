


using Courses.Application.Model;

namespace DataAccessLayer;

public class CoursesEntityConfiguration : IEntityTypeConfiguration<Course>
{
    public void Configure(EntityTypeBuilder<Course> builder)
    {
        builder.ToTable("Courses");
        builder.HasKey(c => c.CourseID);
        builder.Property(c=>c.CourseName).IsRequired().HasMaxLength(80);
        builder.Property(c=>c.Description).IsRequired().HasMaxLength(200);
        builder.Property(c=>c.CourseCode).IsUnicode(true);

        builder.HasMany(c => c.Enrollments)
            .WithOne(e => e.Course)
            .HasForeignKey(e => e.CourseId);
        builder.HasMany(c => c.Exams)
            .WithOne(e => e.Course)
            .HasForeignKey(e => e.CourseId);
    }
}
