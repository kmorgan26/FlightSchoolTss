using FluentValidation;
using FlightSchoolTss.DTOs.Authentication;

namespace FlightSchoolTss.Data.ViewModels.Auth;

public class RegisterUserValidator : AbstractValidator<RegisterUserDto>
{
    public RegisterUserValidator()
    {
        RuleFor(i => i.EmailAddress)
            .NotEmpty()
            .EmailAddress();

        RuleFor(i => i.Password)
            .MinimumLength(6)
            .MaximumLength(16);

        RuleFor(i => i.FirstName)
            .NotEmpty();
        RuleFor(i => i.LastName)
            .NotEmpty();
    }
}