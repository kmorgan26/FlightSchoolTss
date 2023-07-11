using FluentValidation;
using FlightSchoolTss.Data.Interfaces;
using FlightSchoolTss.Data.DTOs.Lot;

namespace FlightSchoolTss.Data.Validators.Lot;

public class LotDtoValidator : AbstractValidator<LotDto>
{
    private readonly ILotRepository _repository;

    public LotDtoValidator(ILotRepository repository)
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

        RuleFor(i => i.PlatformId)
            .MustAsync(async (id, token) =>
            {
                var platformExists = await _repository!.Exists(id);
                return platformExists;
            })
            .WithMessage("You have not provided a valid Platform for this Lot");
    }
}