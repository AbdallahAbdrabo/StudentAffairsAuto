using Students.Application.Model;

namespace DataAccessLayer;

public class StudentEntityConfiguration : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.ToTable("Students");
        builder.HasKey(s=>s.StudentId);
        builder.Property(s => s.StudentId);
               
        builder.Property(s=>s.Name)
            .IsRequired()
            .HasMaxLength(70);
        builder.Property(s => s.DateOfBirth)
            .IsRequired();
        builder.Property(s => s.Address)
            .IsRequired()
            .HasMaxLength(50);
        builder.Property(s => s.NationalID)
            .IsRequired()
            .HasMaxLength(20);
        builder.Property(s => s.PhoneNumber)
            .IsRequired()
            .HasMaxLength(13);

        builder.HasMany(s => s.Enrollments)
            .WithOne(e => e.Student)
            .HasForeignKey(e => e.StudentId);
        
    }

  
}
