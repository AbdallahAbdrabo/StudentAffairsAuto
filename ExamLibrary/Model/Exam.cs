namespace Exams.Application.Model;

public class Exam
{
    public int ExamId { get; set; }
    public DateOnly ExamDate { get; set; }
    public string? ExamType { get; set; }
    public int MaxMarks { get; set; }

    public int CourseId { get; set; }
    

    public ICollection<ExamResult>? ExamResults { get; set; }
}
