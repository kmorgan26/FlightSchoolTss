using FlightSchoolTss.Data.DTOs.HardwareVersion;
using FluentValidation;

namespace FlightSchoolTss.Data.Validators.HardwareVersion;

public class HardwareVersionDtoValidator : AbstractValidator<HardwareVersionDto>
{
    public HardwareVersionDtoValidator()
    {
        RuleFor(dto => dto.Name)
            .NotEmpty().WithMessage("Name is required.")
            .MaximumLength(50).WithMessage("Name must not exceed 50 characters.");

        RuleFor(dto => dto.HardwareSystemId)
            .NotEmpty().WithMessage("HardwareSystemId is required.")
            .GreaterThan(0).WithMessage("HardwareSystemId must be greater than 0.");

        RuleFor(dto => dto.VersionDate)
            .NotEmpty().WithMessage("Version Date is required");
    }
}