using Microsoft.AspNetCore.Identity;
using WebApiTraining.DTOs.Authentication;

namespace WebApiTraining.Services;
public interface IAuthManager
{
    Task<AuthResponseDto> Login(LoginDto loginDto);
    Task<IEnumerable<IdentityError>> Register(RegisterUserDto registerUserDto);
}