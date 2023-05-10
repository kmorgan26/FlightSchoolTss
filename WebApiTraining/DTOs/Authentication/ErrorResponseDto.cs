namespace WebApiTraining.DTOs.Authentication;

public class ErrorResponseDto
{
    public string Code { get; set; } = null!;
    public string Description { get; set; } = null!;
}