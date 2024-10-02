namespace faculties.Application;

public class FacultyEntityConfiguration : IEntityTypeConfiguration<Faculty>
{
    public void Configure(EntityTypeBuilder<Faculty> builder)
    {
        builder.ToTable("Faculties");
      
        builder.HasKey(f => f.FucultyId);
        
        builder.Property(f => f.FucultyId)
               .IsRequired();
        
        builder.Property(f => f.Name)
               .IsRequired(false)
               .HasMaxLength(100); 
      
        builder.Property(f => f.Email)
               .IsRequired(false)
               .HasMaxLength(100); 
      
        builder.Property(f => f.PhoneNumber)
               .IsRequired(false)
               .HasMaxLength(15);
       
        builder.Property(f => f.OfficeLocation)
               .IsRequired(false)
               .HasMaxLength(50);

        builder.Property(f => f.Position)
               .IsRequired(false)
               .HasMaxLength(50); 

        builder.Property(f => f.DepartmentId)
               .IsRequired(true);

        builder.HasOne(f => f.Department)
               .WithMany()
               .HasForeignKey(f => f.DepartmentId)
               .OnDelete(DeleteBehavior.Restrict); 
    }
}