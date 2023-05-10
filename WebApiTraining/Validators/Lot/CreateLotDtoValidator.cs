using FluentValidation;
using WebApiTraining.Data.Interfaces;
using WebApiTraining.DTOs.Lot;

namespace WebApiTraining.Validators.Lot;

public class CreateLotDtoValidator : AbstractValidator<CreateLotDto>
{
    private readonly ILotRepository _repository;

    public CreateLotDtoValidator(ILotRepository repository)
    {
        _repository = repository;

        RuleFor(i => i.Name)
            .NotEmpty()
            .NotNull()
            .MinimumLength(5)
            .MaximumLength(10);

        RuleFor(i => i.PlatformId)
            .MustAsync(async (id, token) =>
            {
                var platformExists = await _repository!.Exists(id);
                return platformExists;
            })
            .WithMessage("You have not provided a valid Platform for this Lot");
    }
}