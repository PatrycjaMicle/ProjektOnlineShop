﻿using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using RestApiZamowienia.Dto;
using RestApiZamowienia.Exceptions;
using RestApiZamowienia.Helpers;
using RestApiZamowienia.Models;
using RestApiZamowienia.Models.Context;
using RestApiZamowienia.Services.Interfaces;

namespace RestApiZamowienia.Services;

public class AccountService : IAccountService
{
    private readonly AuthenticationSettings _authenticationSettings;
    private readonly SklepInternetowyContext _context;
    private readonly IPasswordHasher<Uzytkownik> _passwordHasher;

    public AccountService(AuthenticationSettings authenticationSettings, IPasswordHasher<Uzytkownik> passwordHasher,
        SklepInternetowyContext context)
    {
        _authenticationSettings = authenticationSettings;
        _passwordHasher = passwordHasher;
        _context = context;
    }

    public async Task RegisterUser(RegisterUserDto registerDto)
    {
        var nowyUzytkownik = new Uzytkownik
        {
            Imie = registerDto.Imie,
            Nazwisko = registerDto.Nazwisko,
            Email = registerDto.Email,
            RolaUzytkownikaId = 1
        };

        nowyUzytkownik.ZahaszowaneHaslo = _passwordHasher.HashPassword(nowyUzytkownik, registerDto.Password);
        await _context.Uzytkowniks.AddAsync(nowyUzytkownik);
        await _context.SaveChangesAsync();
    }

    public async Task<string> GenerateJwt(LoginDto dto)
    {
        var uzytkownik = await _context.Uzytkowniks
            .FirstOrDefaultAsync(a => a.Email == dto.Email);

        var rolaUzytkownika =
            await _context.RolaUzytkownika.FirstOrDefaultAsync(a => a.Id == uzytkownik.RolaUzytkownikaId);

        if (uzytkownik is null)
            throw new BadRequestException("Invalid username or password");

        var result = _passwordHasher.VerifyHashedPassword(uzytkownik, uzytkownik.ZahaszowaneHaslo, dto.Password);
        if (result == PasswordVerificationResult.Failed)
            throw new BadRequestException("Invalid username or password");

        var claims = new List<Claim>
        {
            new(ClaimTypes.NameIdentifier, uzytkownik.IdUzytkownika.ToString()),
            new(ClaimTypes.Role, rolaUzytkownika.Name)
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authenticationSettings.JwtKey));
        var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var expires = DateTime.Now.AddDays(_authenticationSettings.JwtExpireDays);

        var token = new JwtSecurityToken(_authenticationSettings.JwtIssuer,
            _authenticationSettings.JwtIssuer,
            claims,
            expires: expires,
            signingCredentials: cred);

        var tokenHandler = new JwtSecurityTokenHandler();
        return tokenHandler.WriteToken(token);
    }

    public Task DeleteUser(string email)
    {
        throw new NotImplementedException();
    }
}