﻿namespace FlightSchoolTss.DTOs.Authentication;
public class LoginDto
{
    public string EmailAddress { get; set; } = null!;
    public string Password { get; set; } = null!;
}