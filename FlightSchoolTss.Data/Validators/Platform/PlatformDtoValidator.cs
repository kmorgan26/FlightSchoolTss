using FlightSchoolTss.Data.DTOs.Maintainer;
using FlightSchoolTss.Data.Interfaces;
using FlightSchoolTss.DTOs.Platform;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSchoolTss.Data.Validators.Platform;
public class PlatformDtoValidator : AbstractValidator<PlatformDto>
{
    private readonly IPlatformRepository _repository;
    public PlatformDtoValidator(IPlatformRepository repository)
    {
        _repository = repository;

        RuleFor(i => i.Name)
           .NotEmpty()
           .NotNull()
           .MinimumLength(3).WithMessage("Please use at least 3 characters for the name")
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
    public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
    {
        var result = await ValidateAsync(ValidationContext<PlatformDto>.CreateWithOptions((PlatformDto)model, x => x.IncludeProperties(propertyName)));
        if (result.IsValid)
            return Array.Empty<string>();
        return result.Errors.Select(e => e.ErrorMessage);
    };
}
