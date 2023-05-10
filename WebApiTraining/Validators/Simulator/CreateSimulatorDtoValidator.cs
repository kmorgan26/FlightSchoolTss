using FluentValidation;
using WebApiTraining.Data.Interfaces;
using WebApiTraining.DTOs.Simulator;

namespace WebApiTraining.Validators.Simulator;

public class CreateSimulatorDtoValidator : AbstractValidator<CreateSimulatorDto>
{
    private readonly ISimulatorRepository _repository;
    public CreateSimulatorDtoValidator(ISimulatorRepository repository)
    {
        _repository = repository;

        RuleFor(i => i.Name)
            .NotEmpty()
            .NotNull()
            .MinimumLength(4)
            .MaximumLength(15).WithMessage("The Name of this is wrong");

        RuleFor(i => i.PlatformId)
            .MustAsync(async (id, token) =>
            {
                var platformExists = await _repository!.Exists(id);
                return platformExists;
            })
            .WithMessage("You have not provided a valid Platform for this Simulator");
    }
}
