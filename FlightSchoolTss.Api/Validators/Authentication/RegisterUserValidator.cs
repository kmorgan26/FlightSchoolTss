﻿using FluentValidation;
using FlightSchoolTss.DTOs.Authentication;

namespace FlightSchoolTss.Validators.Authentication;

public class RegisterUserValidator : AbstractValidator<RegisterUserDto>
{
    public RegisterUserValidator()
    {
        RuleFor(i => i.EmailAddress)
            .NotEmpty()
            .EmailAddress();

        RuleFor(i => i.Password)
            .MinimumLength(12)
            .MaximumLength(20);

        RuleFor(i => i.FirstName)
            .NotEmpty();
        RuleFor(i => i.LastName)
            .NotEmpty();
    }
}