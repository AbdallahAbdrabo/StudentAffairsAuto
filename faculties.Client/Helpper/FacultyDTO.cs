namespace faculties.Client
{
    public class FacultyDTO
    {
        public int? FucultyId { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? OfficeLocation { get; set; }
        public string? Position { get; set; } //Professor, Assistant Professor, Lecturer

        public int DepartmentId { get; set; }
    }
}
