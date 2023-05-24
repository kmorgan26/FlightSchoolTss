using FlightSchoolTss.Api.DTOs.SoftwareVersion;
using FluentValidation;

namespace FlightSchoolTss.Api.Validators.SoftwareVersion;

public class CreateSoftwareVersionDtoValidator : AbstractValidator<CreateSoftwareVersionDto>
{
    public CreateSoftwareVersionDtoValidator()
    {
        RuleFor(dto => dto.Name)
            .NotEmpty().WithMessage("Name is required.")
            .MaximumLength(50).WithMessage("Name must not exceed 50 characters.");

        RuleFor(dto => dto.SoftwareSystemId)
            .NotEmpty().WithMessage("SoftwareSystemId is required.")
            .GreaterThan(0).WithMessage("SoftwareSystemId must be greater than 0.");

        RuleFor(dto => dto.VersionDate)
            .NotEmpty().WithMessage("Version Date is required");
    }
}
