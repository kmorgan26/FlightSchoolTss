﻿namespace FlightSchoolCm.UI.ViewModels.Auth;

public class RegistrationVm
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string EmailAddress { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string ConfirmPassword { get; set; } = null!;

}
