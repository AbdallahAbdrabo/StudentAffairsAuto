

namespace Courses.Client;

public class Coursesvalidator : AbstractValidator<CourseDTO>
{
    private readonly IStringLocalizer<Resource> _localizer;

    public Coursesvalidator(IStringLocalizer<Resource> localizer)
    {
        _localizer = localizer;

        RuleFor(s => s.CourseName)
                  .NotEmpty().WithMessage(_localizer["NameValidation"]);

        RuleFor(s => s.Description)
            .NotEmpty().WithMessage(_localizer["DescriptionValidation"]); // Ensuring Description is not empty

        RuleFor(s => s.CourseCode)
            .NotEmpty().WithMessage(_localizer["CourseCodeValidation"]) // Ensuring CourseCode is not empty
            .Matches(@"^[A-Z]{2}\d{3}$").WithMessage(_localizer["CourseCodeFormatValidation"]); // Example format: CS101

        RuleFor(s => s.DepartmentId)
            .NotEmpty().WithMessage(_localizer["DepartmentIdValidation"]); // Ensuring DepartmentId is not empty


    }
}
