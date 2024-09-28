



using Attendances.Application.Model;

namespace DataAccessLayer;
public class AttendanceEntittyConfiguration : IEntityTypeConfiguration<Attendance>
{
    public void Configure(EntityTypeBuilder<Attendance> builder)
    {
        builder.ToTable("Attendance");
        builder.HasKey(a => a.AttendanceId);

        builder.HasOne(a => a.Student)
           .WithMany(s => s.Attendances)
           .HasForeignKey(a => a.StudentId);

        builder.HasOne(a => a.Course)
           .WithMany(s => s.Attendances)
           .HasForeignKey(a => a.CourseId);
    }

  
}
