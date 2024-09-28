


using Exams.Application.Model;

namespace DataAccessLayer;

public class ExamsEntityConfiguration : IEntityTypeConfiguration<Exam>
{
    public void Configure(EntityTypeBuilder<Exam> builder)
    {
        builder.ToTable("Exams");
        builder.HasKey(e => e.ExamId);
        builder.Property(e => e.ExamType)
            .IsRequired().HasMaxLength(50);

        builder.HasMany(e => e.ExamResults)
            .WithOne(e => e.Exam)
            .HasForeignKey(e => e.ExamId);


    }
}
