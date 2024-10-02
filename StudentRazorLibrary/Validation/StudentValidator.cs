

using Microsoft.Extensions.Localization;
using Students.Client.Resources;

namespace StudentBlazor;

public class StudentValidator : AbstractValidator<StudentDTO>
{
    private readonly IStringLocalizer<Resource> _localizer;

    public StudentValidator(IStringLocalizer<Resource> localizer)
    {
        _localizer = localizer;

        RuleFor(s => s.Name)
            .NotEmpty().WithMessage(_localizer["NameValidation"]);

        RuleFor(s => s.Email)
            .NotEmpty().WithMessage(_localizer["EmailValidation"])
            .EmailAddress().WithMessage(_localizer["A valid email is required."]);

        RuleFor(s => s.NationalID)
            .NotEmpty().WithMessage(_localizer["NationalIDValidation"]);

        RuleFor(s => s.Gender)
            .NotEmpty().WithMessage(_localizer["GenderValidation"]);

        RuleFor(s => s.PhoneNumber)
            .NotEmpty().WithMessage(_localizer["PhoneNumberValidattion"]);

        RuleFor(s => s.Address)
            .NotEmpty().WithMessage(_localizer["AddressValidation"]);



    }
}
