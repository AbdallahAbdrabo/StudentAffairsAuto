
using FluentValidation;

namespace StudentBlazor;

public class StudentValidator : AbstractValidator<StudentDTO>
{
    public StudentValidator()
    {
        RuleFor(s => s.Name)
            .NotEmpty().WithMessage("Name is required");

        RuleFor(s => s.Email)
            .NotEmpty().WithMessage("Email is required")
            .EmailAddress().WithMessage("A valid email is required."); ;

        RuleFor(s => s.DateOfBirth).
            NotEmpty().WithMessage("Date Of Birth is required");

        RuleFor(s => s.PhoneNumber)
            .NotEmpty().WithMessage("Mobile is required");

      

    }
}
