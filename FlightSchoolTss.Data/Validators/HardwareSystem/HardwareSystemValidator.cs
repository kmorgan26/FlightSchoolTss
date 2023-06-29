using FlightSchoolTss.Data.DTOs.HardwareSystem;
using FluentValidation;

namespace FlightSchoolTss.Data.Validators.HardwareSystem;
public class HardwareSystemDtoValidator : AbstractValidator<HardwareSystemDto>
{
    public HardwareSystemDtoValidator()
    {
        RuleFor(dto => dto.Name)
            .NotEmpty().WithMessage("Name is required.")
            .MaximumLength(20).WithMessage("Name must not exceed 20 characters.");

        RuleFor(dto => dto.MaintainableId)
            .NotEmpty().WithMessage("MaintainableId is required.")
            .GreaterThan(0).WithMessage("MaintainableId must be greater than 0.");

    }
}
