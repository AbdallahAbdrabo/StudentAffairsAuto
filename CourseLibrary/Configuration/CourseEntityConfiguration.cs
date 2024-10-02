namespace Courses.Application;
public class CourseEntityConfiguration : IEntityTypeConfiguration<Course>
{
    public void Configure(EntityTypeBuilder<Course> builder)
    {
        
        builder.ToTable("Courses");

       
        builder.HasKey(c => c.CourseID);

       
        builder.Property(c => c.CourseID)
               .IsRequired(); 

       
        builder.Property(c => c.CourseName)
               .IsRequired()
               .HasMaxLength(100);

        builder.Property(c => c.Description)
               .HasMaxLength(500);

        builder.Property(c => c.CourseCode)
               .IsRequired()
               .HasMaxLength(10);


        builder.Property(c => c.DepartmentId)
               .IsRequired();

    }
}