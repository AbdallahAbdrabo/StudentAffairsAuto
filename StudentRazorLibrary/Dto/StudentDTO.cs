namespace Students.Client.Dto;

public class StudentDTO
{
    public int? StudentId { get; set; }
    public string? Name { get; set; }
    public DateOnly DateOfBirth { get; set; }
    public string? Gender { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Email { get; set; }
    public string? Address { get; set; }
    public string? NationalID { get; set; }
    public string? EnrollmentStatus { get; set; }
    public decimal GPA { get; set; }
}
