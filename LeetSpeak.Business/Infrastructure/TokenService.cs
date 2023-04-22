using LeetSpeak.Abstractions;
using LeetSpeak.Shared.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace LeetSpeak.Business.Services
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;

        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public TokenResponse CreateAccessToken(int min)
        {
            TokenResponse tokenResponse = new();

            SymmetricSecurityKey securityKey = new(Encoding.UTF8.GetBytes(_configuration["Token:SecurityKey"]));

            SigningCredentials signingCredentials = new(securityKey, SecurityAlgorithms.HmacSha256);

            tokenResponse.ExpirationDate = DateTime.Now.AddMinutes(min);

            JwtSecurityToken securityToken = new(
                expires: tokenResponse.ExpirationDate,
                signingCredentials: signingCredentials,
                audience: _configuration["Token:Audience"],
                issuer: _configuration["Token:Issuer"],
                notBefore: DateTime.UtcNow
                );
            JwtSecurityTokenHandler tokenHandler = new();
            tokenResponse.AccessToken = tokenHandler.WriteToken(securityToken);
            return tokenResponse;
        }

    }
}