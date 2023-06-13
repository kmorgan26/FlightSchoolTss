using FlightSchoolTss.Data.Interfaces;
using FlightSchoolTss.DTOs.Simulator;
using FluentValidation;

namespace FlightSchoolTss.Data.Validators.Simulator;

public class CreateSimulatorDtoValidator : AbstractValidator<CreateSimulatorDto>
{
    private readonly ISimulatorRepository _repository;
    public CreateSimulatorDtoValidator(ISimulatorRepository repository)
    {
        _repository = repository;

        RuleFor(i => i.Name)
            .NotEmpty()
            .NotNull()
            .MinimumLength(4).WithMessage("Please use at least 4 characters for the name")
            .MaximumLength(50).WithMessage("The name cannot be more than 50 characters");

        RuleFor(i => i.PlatformId)
            .MustAsync(async (id, token) =>
            {
                var platformExists = await _repository!.Exists(id);
                return platformExists;
            })
            .WithMessage("You have not provided a valid Platform for this Simulator");

        RuleFor(dto => dto.MaintainableId)
            .NotEmpty().WithMessage("MaintainableId is required.")
            .GreaterThan(0).WithMessage("MaintainableId must be greater than 0.");
    }
}
