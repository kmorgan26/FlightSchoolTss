﻿namespace FlightSchoolTss.Api.DTOs.HardwareConfiguration;

public class CreateHardwareConfigurationDto
{
    public int ConfigurationItemId { get; set; }
    public string Name { get; set; } = null!;
}
