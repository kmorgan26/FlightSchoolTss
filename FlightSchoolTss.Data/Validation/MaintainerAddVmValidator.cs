using FlightSchoolTss.Data.ViewModels.Maintainer;
using FluentValidation;

namespace FlightSchoolTss.Data.Validation;

public class MaintainerAddVmValidator : FluentValueValidator<AddMaintainerVm>
{
    public MaintainerAddVmValidator()
    {
        
    }
    //public MaintainerAddVmValidator()
    //{
    //    RuleFor(m => m.Name)
    //        .NotEmpty()
    //            .WithMessage("The Maintainer Name is Required")
    //        .MaximumLength(25)
    //            .WithMessage("The name of the Maintainer must be 25 characters or less")
    //        .MinimumLength(3)
    //            .WithMessage("The name of the Maintainer must be at least 3 characters long");
    //}

    //public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
    //{
    //    var result = await ValidateAsync(ValidationContext<AddMaintainerVm>.CreateWithOptions((AddMaintainerVm)model, x => x.IncludeProperties(propertyName)));
    //    if (result.IsValid)
    //        return Array.Empty<string>();
    //    return result.Errors.Select(e => e.ErrorMessage);
    //};
}
