

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Students.Application;

public class StudentEntityConfiguration : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.ToTable("Students");
        builder.HasKey(s => s.StudentId);
        builder.Property(s => s.StudentId)
               .ValueGeneratedNever();
        builder.Property(s => s.Name)
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


    }

 
}
