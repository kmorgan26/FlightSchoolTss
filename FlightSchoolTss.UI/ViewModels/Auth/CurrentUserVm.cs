namespace FlightSchoolTss.UI.ViewModels.Auth;

public class CurrentUserVm
{
    public string FirstName { get; set; } = null!;
    public bool IsAuthenticated { get; set; }
    public Dictionary<string, string> Claims { get; set; } = null!;
}