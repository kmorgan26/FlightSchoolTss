using FlightSchoolTss.Api.DTOs.SoftwareVersionLoad;
using FluentValidation;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace FlightSchoolTss.Api.Validators.SoftwareVersionLoad;

public class CreateSoftwareVersionLoadDtoValidator : AbstractValidator<CreateSoftwareVersionLoadDto>
{
    public CreateSoftwareVersionLoadDtoValidator()
    {
        RuleFor(dto => dto.SoftwareVersionId)
            .NotEmpty().WithMessage("SoftwareVersionId is required.")
            .GreaterThan(0).WithMessage("SoftwareVersionId must be greater than 0.");

        RuleFor(dto => dto.SoftwareLoadId)
            .NotEmpty().WithMessage("SoftwareLoadId is required.")
            .GreaterThan(0).WithMessage("SoftwareLoadId must be greater than 0.");
    }
}
