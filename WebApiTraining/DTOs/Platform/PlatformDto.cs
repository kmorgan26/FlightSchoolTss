namespace WebApiTraining.DTOs.Platform;

public class PlatformDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public bool IsActive { get; set; }
    public int MaintainerId { get; set; }
}