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
            .MinimumLength(3)
            .MaximumLength(15);
    }
}