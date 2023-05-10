namespace WebApiTraining.DTOs.Authentication;
public class RegisterUserDto : LoginDto
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
}