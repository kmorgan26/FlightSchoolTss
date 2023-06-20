using FluentValidation;
using FlightSchoolTss.Data.Interfaces;
using FlightSchoolTss.Data.DTOs.Platform;

namespace FlightSchoolTss.Data.Validators.Platform;

public class CreatePlatformDtoValidator : AbstractValidator<CreatePlatformDto>
{
    private readonly IPlatformRepository _repository;

    public CreatePlatformDtoValidator(IPlatformRepository repository)
    {
        _repository = repository;

        RuleFor(i => i.Name)
            .NotEmpty()
            .NotNull()
            .MinimumLength(5).WithMessage("Please use at least 5 characters for the name")
            .MaximumLength(50).WithMessage("The name cannot be more than 50 characters");

        RuleFor(dto => dto.MaintainableId)
            .NotEmpty().WithMessage("MaintainableId is required.")
            .GreaterThan(0).WithMessage("MaintainableId must be greater than 0.");

        RuleFor(i => i.MaintainerId)
            .MustAsync(async (id, token) =>
            {
                var maintainerExists = await _repository!.Exists(id);
                return maintainerExists;
            })
            .WithMessage("You have not provided a valid Maintainer for this Platform");

        RuleFor(i => i.IsActive)
            .NotEmpty();
    }
}
