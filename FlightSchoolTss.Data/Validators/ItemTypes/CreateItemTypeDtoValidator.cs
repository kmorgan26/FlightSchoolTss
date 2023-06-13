using FlightSchoolTss.Data.DTOs.ItemTypes;
using FluentValidation;

namespace FlightSchoolTss.Data.Validators.ItemTypes;

public class CreateItemTypeDtoValidator : AbstractValidator<CreateItemTypeDto>
{
    public CreateItemTypeDtoValidator()
    {
        RuleFor(i => i.Name)
            .NotEmpty()
            .NotNull()
            .MinimumLength(5).WithMessage("Please use at least 5 characters for the name")
            .MaximumLength(50).WithMessage("The name cannot be more than 50 characters");
    }
}
