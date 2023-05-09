namespace WebApiTraining.DTOs.Authentication;
public class LoginDto
{
    public string UserName { get; set; } = null!;
    public string Password { get; set; } = null!;
}