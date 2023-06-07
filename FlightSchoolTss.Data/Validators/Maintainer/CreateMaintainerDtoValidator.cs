using FluentValidation;
using FlightSchoolTss.DTOs.Maintainer;

namespace FlightSchoolTss.Validators.Lot;

public class CreateMaintainerDtoValidator : AbstractValidator<CreateMaintainerDto>
{
    public CreateMaintainerDtoValidator()
    {
        RuleFor(i => i.Name)
            .NotEmpty()
            .NotNull()
            .MinimumLength(5).WithMessage("Please use at least 5 characters for the name")
            .MaximumLength(50).WithMessage("The name cannot be more than 50 characters");
    }
}