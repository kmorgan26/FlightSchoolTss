﻿using FlightSchoolTss.Data.ViewModels.Auth;
using FluentValidation;

namespace FlightSchoolTss.Data.ViewModels.Auth;

public class LoginValidationVm : AbstractValidator<LoginVm>
{
    public LoginValidationVm()
    {
        RuleFor(_ => _.EmailAddress).EmailAddress().NotEmpty();
    }
    public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
    {
        var result = await ValidateAsync(ValidationContext<LoginVm>.CreateWithOptions((LoginVm)model, x => x.IncludeProperties(propertyName)));
        if (result.IsValid)
            return Array.Empty<string>();
        return result.Errors.Select(e => e.ErrorMessage);
    };
}
