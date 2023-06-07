using FlightSchoolTss.Data.DTOs.Maintainable;
using FlightSchoolTss.DTOs.Maintainer;
using FluentValidation;

namespace FlightSchoolTss.Api.Validators.Maintainable;

public class CreateMaintainableDtoValidator : AbstractValidator<CreateMaintainableDto>
{
    public CreateMaintainableDtoValidator()
    {
        RuleFor(i => i.Name)
            .NotEmpty()
            .NotNull()
            .MinimumLength(5).WithMessage("Please use at least 5 characters for the name")
            .MaximumLength(150).WithMessage("The Maximum length of the name is 150 characters");
    }
}
