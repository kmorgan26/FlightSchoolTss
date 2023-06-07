using FlightSchoolTss.Data.DTOs.Configuration;
using FluentValidation;

namespace FlightSchoolTss.Api.Validators.Configuration;

public class CreateConfigurationDtoValidator : AbstractValidator<CreateConfigurationDto>
{
    public CreateConfigurationDtoValidator()
    {
        RuleFor(dto => dto.ConfigurationItemId)
            .NotEmpty().WithMessage("ConfigurationItemId is required.")
            .GreaterThan(0).WithMessage("ConfigurationItemId must be greater than 0.");

        RuleFor(dto => dto.MaintainableId)
            .NotEmpty().WithMessage("MaintainableId is required.")
            .GreaterThan(0).WithMessage("MaintainableId must be greater than 0.");

    }
}