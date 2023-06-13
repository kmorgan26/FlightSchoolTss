using FlightSchoolTss.Data.DTOs.HardwareConfiguration;
using FluentValidation;

namespace FlightSchoolTss.Data.Validators.HardwareConfiguration;
public class CreateHardwareConfigurationDtoValidator : AbstractValidator<CreateHardwareConfigurationDto>
{
    public CreateHardwareConfigurationDtoValidator()
    {
        RuleFor(dto => dto.ConfigurationItemId)
            .NotEmpty().WithMessage("ConfigurationItemId is required.")
            .GreaterThan(0).WithMessage("ConfigurationItemId must be greater than 0.");

        RuleFor(dto => dto.Name)
            .NotEmpty().WithMessage("Name is required.")
            .MaximumLength(50).WithMessage("Name must not exceed 50 characters.");
    }
}

