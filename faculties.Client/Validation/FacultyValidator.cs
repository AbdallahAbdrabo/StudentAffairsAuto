namespace faculties.Client;

public class FacultyValidator : AbstractValidator<FacultyDTO>
{
    public FacultyValidator()
    {

        RuleFor(f => f.Name)
            .NotEmpty().WithMessage("Name is required.")
            .MaximumLength(100).WithMessage("Name cannot exceed 100 characters.");


        RuleFor(f => f.Email)
            .NotEmpty().WithMessage("Email is required.")
            .EmailAddress().WithMessage("Invalid email address.")
            .MaximumLength(100).WithMessage("Email cannot exceed 100 characters.");


        RuleFor(f => f.PhoneNumber)
            .NotEmpty().WithMessage("Phone number is required.")
            .MaximumLength(15).WithMessage("Phone number cannot exceed 15 characters.")
            .Matches(@"^\+?\d{10,15}$").WithMessage("Invalid phone number format.");

        RuleFor(f => f.OfficeLocation)
            .MaximumLength(50).WithMessage("Office location cannot exceed 50 characters.")
            .When(f => !string.IsNullOrEmpty(f.OfficeLocation));

        RuleFor(f => f.Position)
            .MaximumLength(50).WithMessage("Position cannot exceed 50 characters.")
            .When(f => !string.IsNullOrEmpty(f.Position));

        RuleFor(f => f.DepartmentId)
            .GreaterThan(0).WithMessage("Department ID is required and must be greater than 0.");
    }
}