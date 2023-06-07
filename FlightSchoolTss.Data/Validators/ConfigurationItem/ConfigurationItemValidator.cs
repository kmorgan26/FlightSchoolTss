using FlightSchoolTss.Data.DTOs.ConfigurationItem;
using FluentValidation;

namespace FlightSchoolTss.Api.Validators.ConfigurationItem;

public class CreateConfigurationItemDtoValidator : AbstractValidator<CreateConfigurationItemDto>
{
    public CreateConfigurationItemDtoValidator()
    {
        RuleFor(dto => dto.Name)
            .NotEmpty().WithMessage("Name is required.")
            .MaximumLength(50).WithMessage("Name must not exceed 50 characters.");

        RuleFor(dto => dto.ItemTypeId)
            .NotEmpty().WithMessage("ItemTypeId is required.")
            .GreaterThan(0).WithMessage("ItemTypeId must be greater than 0.");

    }
}