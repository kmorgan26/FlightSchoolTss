using FlightSchoolTss.Data.DTOs.Configuration;
using FluentValidation;

namespace FlightSchoolTss.Data.Validators.Configuration;

public class ConfigurationDtoValidator : AbstractValidator<ConfigurationDto>
{
    public ConfigurationDtoValidator()
    {
        RuleFor(dto => dto.ConfigurationItemId)
            .NotEmpty().WithMessage("ConfigurationItemId is required.")
            .GreaterThan(0).WithMessage("ConfigurationItemId must be greater than 0.");

        RuleFor(dto => dto.MaintainableId)
            .NotEmpty().WithMessage("MaintainableId is required.")
            .GreaterThan(0).WithMessage("MaintainableId must be greater than 0.");

    }
}