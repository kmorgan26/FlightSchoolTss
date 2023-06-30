using FlightSchoolTss.Data.DTOs.HardwareVersionsConfigurations;
using FluentValidation;

namespace FlightSchoolTss.Data.Validators.HardwareVersionConfiguration;

public class HardwareVersionConfigurationDtoValidator : AbstractValidator<HardwareVersionsConfigurationsDto>
{
    public HardwareVersionConfigurationDtoValidator()
    {
        RuleFor(dto => dto.HardwareVersionId)
            .NotEmpty().WithMessage("HardwareVersionId is required.")
            .GreaterThan(0).WithMessage("HardwareVersionId must be greater than 0.");

        RuleFor(dto => dto.HardwareConfigurationId)
            .NotEmpty().WithMessage("HardwareConfigurationId is required.")
            .GreaterThan(0).WithMessage("HardwareConfigurationId must be greater than 0.");

    }
}

