using System.ComponentModel.DataAnnotations;

namespace Exams.Application.Model;

public class ExamResult
{
    [Key]
    public int ResultID { get; set; }
    public string? MarksObtained { get; set; }

    public int ExamId { get; set; }
    public Exam? Exam { get; set; }

}
