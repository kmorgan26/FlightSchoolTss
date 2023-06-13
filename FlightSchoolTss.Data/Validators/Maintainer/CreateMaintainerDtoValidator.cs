using FluentValidation;
using FlightSchoolTss.DTOs.Maintainer;

namespace FlightSchoolTss.Data.Validators.Maintainer;

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

    public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
    {
        var result = await ValidateAsync(ValidationContext<CreateMaintainerDto>.CreateWithOptions((CreateMaintainerDto)model, x => x.IncludeProperties(propertyName)));
        if (result.IsValid)
            return Array.Empty<string>();
        return result.Errors.Select(e => e.ErrorMessage);
    };
}