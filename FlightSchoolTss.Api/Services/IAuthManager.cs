using Microsoft.AspNetCore.Identity;
using FlightSchoolTss.DTOs.Authentication;

namespace FlightSchoolTss.Services;
public interface IAuthManager
{
    Task<AuthResponseDto> Login(LoginDto loginDto);
    Task<IEnumerable<IdentityError>> Register(RegisterUserDto registerUserDto);
}