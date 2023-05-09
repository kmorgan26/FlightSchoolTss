using Microsoft.AspNetCore.Identity;

namespace WebApiTraining.Data.Entities.Auth;
public class FstssUser : IdentityUser
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
}