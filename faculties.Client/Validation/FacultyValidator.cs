

namespace faculties.Client;

public class FacultyValidator : AbstractValidator<FacultyDTO>
{
    private readonly IStringLocalizer<Resource> _localizer;

    public FacultyValidator(IStringLocalizer<Resource> localizer)
    {
        _localizer = localizer;
        RuleFor(f => f.Name)
            .NotEmpty().WithMessage(_localizer["NameValidation"])
            .MaximumLength(100).WithMessage(_localizer["NameMaximumLength"]);


        RuleFor(f => f.Email)
            .NotEmpty().WithMessage(_localizer["EmailValidation"])
            .EmailAddress().WithMessage(_localizer["EmailAddress"])
            .MaximumLength(100).WithMessage(_localizer["EmailMaximumLength"]);


        RuleFor(f => f.PhoneNumber)
            .NotEmpty().WithMessage(_localizer["PhoneNumberValidattion"])
            .MaximumLength(15).WithMessage(_localizer["PhoneNumbermax"])
            .Matches(@"^\+?\d{10,15}$").WithMessage(_localizer["PhoneNumberFormat"]);

        RuleFor(s => s.OfficeLocation)
                    .NotEmpty().WithMessage(_localizer["OfficeLocationValidtion"]);

        RuleFor(f => f.Position)
            .MaximumLength(50).WithMessage(_localizer["PositionValidation"])
            .When(f => !string.IsNullOrEmpty(f.Position));

        RuleFor(f => f.DepartmentId)
             .NotEmpty().WithMessage(_localizer["DepartmentIdValidation"])
            .GreaterThan(0).WithMessage(_localizer["DepartmentIdGreater"]);
    }
}