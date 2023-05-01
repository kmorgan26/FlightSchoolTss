namespace WebApiTraining.DTOs.Platform;

public class CreatePlatformDto
{
    public int MaintainerId { get; set; }
    public string Name { get; set; }
    public bool IsActive { get; set; } = false;
}