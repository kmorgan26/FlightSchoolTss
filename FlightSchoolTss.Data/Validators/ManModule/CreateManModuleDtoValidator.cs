using FluentValidation;
using FlightSchoolTss.Data.Interfaces;
using FlightSchoolTss.DTOs.ManModule;

namespace FlightSchoolTss.Data.Validators.ManModule;

public class CreateManModuleDtoValidator : AbstractValidator<CreateManModuleDto>
{
    private readonly IManModuleRepository _repository;

    public CreateManModuleDtoValidator(IManModuleRepository repository)
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

        RuleFor(i => i.LotId)
            .MustAsync(async (id, token) =>
            {
                var lotExists = await _repository!.Exists(id);
                return lotExists;
            })
            .WithMessage("You have not provided a valid Lot for this Man Module");
    }
}
