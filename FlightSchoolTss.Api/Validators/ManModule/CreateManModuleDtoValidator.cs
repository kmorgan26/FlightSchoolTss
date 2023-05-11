using FluentValidation;
using FlightSchoolTss.Data.Interfaces;
using FlightSchoolTss.DTOs.ManModule;

namespace FlightSchoolTss.Validators.ManModule;

public class CreateManModuleDtoValidator : AbstractValidator<CreateManModuleDto>
{
    private readonly IManModuleRepository _repository;

    public CreateManModuleDtoValidator(IManModuleRepository repository)
    {
        _repository = repository;

        RuleFor(i => i.Name)
            .NotEmpty()
            .NotNull()
            .MinimumLength(5)
            .MaximumLength(10);

        RuleFor(i => i.LotId)
            .MustAsync(async (id, token) =>
            {
                var lotExists = await _repository!.Exists(id);
                return lotExists;
            })
            .WithMessage("You have not provided a valid Lot for this Man Module");
    }
}
