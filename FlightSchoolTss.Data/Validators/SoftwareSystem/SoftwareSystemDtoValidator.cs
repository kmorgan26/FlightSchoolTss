using FlightSchoolTss.Data.DTOs.SoftwareSystem;
using FluentValidation;

namespace FlightSchoolTss.Data.Validators.SoftwareSystem;

public class SoftwareSystemDtoValidator : AbstractValidator<SoftwareSystemDto>
{
    public SoftwareSystemDtoValidator()
    {
        RuleFor(dto => dto.MaintainableId)
                .NotEmpty().WithMessage("MaintainableId is required.")
                .GreaterThan(0).WithMessage("MaintainableId must be greater than 0.");

        RuleFor(dto => dto.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(50).WithMessage("Name must not exceed 50 characters.");
    }
}
