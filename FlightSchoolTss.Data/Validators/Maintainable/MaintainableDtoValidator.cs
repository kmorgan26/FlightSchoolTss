using FlightSchoolTss.Data.DTOs.Maintainable;
using FlightSchoolTss.Data.DTOs.Maintainer;
using FluentValidation;

namespace FlightSchoolTss.Data.Validators.Maintainable;

public class MaintainableDtoValidator : AbstractValidator<MaintainableDto>
{
    public MaintainableDtoValidator()
    {
        RuleFor(i => i.Name)
            .NotEmpty()
            .NotNull()
            .MinimumLength(5).WithMessage("Please use at least 5 characters for the name")
            .MaximumLength(150).WithMessage("The Maximum length of the name is 150 characters");
    }
}
