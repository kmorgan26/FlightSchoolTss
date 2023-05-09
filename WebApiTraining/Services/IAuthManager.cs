using WebApiTraining.DTOs.Authentication;

namespace WebApiTraining.Services;
public interface IAuthManager
{
    Task<AuthResponseDto> Login(LoginDto loginDto);
}