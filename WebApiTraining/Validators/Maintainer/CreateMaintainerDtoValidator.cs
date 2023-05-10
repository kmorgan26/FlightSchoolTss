using FluentValidation;
using WebApiTraining.DTOs.Maintainer;

namespace WebApiTraining.Validators.Lot;

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