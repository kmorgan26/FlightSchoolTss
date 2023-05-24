﻿using FlightSchoolTss.Api.DTOs.HardwareVersionConfiguration;
using FluentValidation;

namespace FlightSchoolTss.Api.Validators.HardwareVersionConfiguration;

public class CreateHardwareVersionConfigurationDtoValidator : AbstractValidator<CreateHardwareVersionConfigurationDto>
{
    public CreateHardwareVersionConfigurationDtoValidator()
    {
        RuleFor(dto => dto.HardwareVersionId)
            .NotEmpty().WithMessage("HardwareVersionId is required.")
            .GreaterThan(0).WithMessage("HardwareVersionId must be greater than 0.");

        RuleFor(dto => dto.HardwareConfigurationId)
            .NotEmpty().WithMessage("HardwareConfigurationId is required.")
            .GreaterThan(0).WithMessage("HardwareConfigurationId must be greater than 0.");

    }
}

