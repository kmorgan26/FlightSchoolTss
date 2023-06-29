using FlightSchoolTss.Data.DTOs.ConfigurationItem;
using FluentValidation;

namespace FlightSchoolTss.Data.Validators.ConfigurationItem;

public class ConfigurationItemDtoValidator : AbstractValidator<ConfigurationItemDto>
{
    public ConfigurationItemDtoValidator()
    {
        RuleFor(dto => dto.Name)
            .NotEmpty().WithMessage("Name is required.")
            .MaximumLength(50).WithMessage("Name must not exceed 50 characters.");

        RuleFor(dto => dto.ItemTypeId)
            .NotEmpty().WithMessage("ItemTypeId is required.")
            .GreaterThan(0).WithMessage("ItemTypeId must be greater than 0.");

    }
}