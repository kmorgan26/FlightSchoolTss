﻿using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using FlightSchoolTss.Data.Entities.Auth;
using FlightSchoolTss.DTOs.Authentication;
using System.Security.Cryptography;

namespace FlightSchoolTss.Services;
public class AuthManager : IAuthManager
{
    private readonly UserManager<FstssUser> _userManager;
    private readonly IConfiguration _configuration;
    private FstssUser? _user;

    public AuthManager(UserManager<FstssUser> userManager, IConfiguration configuration)
    {
        _userManager = userManager;
        _configuration = configuration;
    }

    public async Task<AuthResponseDto> Login(LoginDto loginDto)
    {
        _user = await _userManager.FindByEmailAsync(loginDto.EmailAddress);

        if (_user is null)
            return default!;

        bool isValidCredentials = await _userManager.CheckPasswordAsync(_user, loginDto.Password);

        if (!isValidCredentials)
            return default!;

        //Generate Token
        var token = await GenerateTokenAsync();

        return new AuthResponseDto
        {
            Token = token,
            UserId = _user.Id,
        };
    }

    public async Task<IEnumerable<IdentityError>> Register(RegisterUserDto registerUserDto)
    {
        var userExists = _userManager.FindByEmailAsync(registerUserDto.EmailAddress);
        var result = new IdentityResult();

        if (userExists.Result is null)
        {
            _user = new FstssUser
            {
                Email = registerUserDto.EmailAddress,
                UserName = registerUserDto.EmailAddress,
                FirstName = registerUserDto.FirstName,
                LastName = registerUserDto.LastName,
            };

            result = await _userManager.CreateAsync(_user, registerUserDto.Password);

            if (result.Succeeded)
                await _userManager.AddToRoleAsync(_user, "User");
        }
        return result.Errors;
    }

    private async Task<string> GenerateTokenAsync()
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSettings:Key"]!));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var roles = await _userManager.GetRolesAsync(_user!);
        var roleClaims = roles.Select(role => new Claim(ClaimTypes.Role, role)).ToList();
        var userClaims = await _userManager.GetClaimsAsync(_user!);

        var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Sub, _user!.Email!),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.Email, _user!.Email!)
        }.Union(userClaims).Union(roleClaims);

        //to do a custom claim, add it this way:
        //new Claim("customName", _user.FirstNameOrCustomField)

        var token = new JwtSecurityToken(
            issuer: _configuration["JwtSettings:Issuer"],
            audience: _configuration["JwtSettings:Audience"],
            claims: claims,
            expires: DateTime.Now.AddHours(Convert.ToInt32(_configuration["JwtSettings:DurationInHours"])),
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
    private string HashedPassword(string plainPassword)
    {
        byte[] salt = new byte[16];
        using (var randomGenerator = RandomNumberGenerator.Create())
        {
            randomGenerator.GetBytes(salt);
        }
        var rfcPassowrd = new Rfc2898DeriveBytes(plainPassword, salt, 1000, HashAlgorithmName.SHA1);
        byte[] rfcPasswordHash = rfcPassowrd.GetBytes(20);

        byte[] passwordHash = new byte[36];
        Array.Copy(salt, 0, passwordHash, 0, 16);
        Array.Copy(rfcPasswordHash, 0, passwordHash, 16, 20);

        return Convert.ToBase64String(passwordHash);
    }


}