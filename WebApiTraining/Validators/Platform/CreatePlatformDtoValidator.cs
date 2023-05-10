using FluentValidation;
using WebApiTraining.Data.Interfaces;
using WebApiTraining.DTOs.Platform;

namespace WebApiTraining.Validators.Platform;

public class CreatePlatformDtoValidator : AbstractValidator<CreatePlatformDto>
{
    private readonly IPlatformRepository _repository;

    public CreatePlatformDtoValidator(IPlatformRepository repository)
    {
        _repository = repository;

        RuleFor(i => i.Name)
            .NotEmpty()
            .NotNull()
            .MinimumLength(5)
            .MaximumLength(15);

        RuleFor(i => i.MaintainerId)
            .MustAsync(async (id, token) =>
            {
                var maintainerExists = await _repository!.Exists(id);
                return maintainerExists;
            })
            .WithMessage("You have not provided a valid Maintainer for this Platform");
    }
}
