using FluentValidation;
using FlightSchoolTss.DTOs.Maintainer;

namespace FlightSchoolTss.Validators.Maintainer;

public class MaintainerDtoValidator : AbstractValidator<MaintainerDto>
{
    public MaintainerDtoValidator()
    {
        RuleFor(i => i.Name)
            .NotEmpty()
            .NotNull()
            .MinimumLength(3).WithMessage("Please use at least 3 characters for the name")
            .MaximumLength(50).WithMessage("The name cannot be more than 50 characters");
    }
    public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
    {
        var result = await ValidateAsync(ValidationContext<MaintainerDto>.CreateWithOptions((MaintainerDto)model, x => x.IncludeProperties(propertyName)));
        if (result.IsValid)
            return Array.Empty<string>();
        return result.Errors.Select(e => e.ErrorMessage);
    };
}