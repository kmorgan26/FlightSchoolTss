using FlightSchoolTss.Api.DTOs.SoftwareSystem;
using FluentValidation;

namespace FlightSchoolTss.Api.Validators.SoftwareSystem;

public class CreateSoftwareSystemDtoValidator : AbstractValidator<CreateSoftwareSystemDto>
{
    public CreateSoftwareSystemDtoValidator()
    {
        RuleFor(dto => dto.MaintainableId)
                .NotEmpty().WithMessage("MaintainableId is required.")
                .GreaterThan(0).WithMessage("MaintainableId must be greater than 0.");

        RuleFor(dto => dto.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(50).WithMessage("Name must not exceed 50 characters.");
    }
}
