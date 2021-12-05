using Application.Contracts;
using Application.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Identity
{
    public class AuthService : IAuthService
    {
        private readonly JwtSettings _jwtSettings;
        public AuthService(IOptions<JwtSettings> jwtSettings)
        {
            _jwtSettings = jwtSettings.Value;
        }

        public AuthResponse Login(AuthRequest request)
        {
            if (!request.Username.Equals("testclient") && !request.Password.Equals("clientpassword"))
            {
                throw new Exception("Invalid credentials");
            }

            return new AuthResponse { Token = GenerateToken(request) };
        }

        private string GenerateToken(AuthRequest request)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.ASCII.GetBytes(_jwtSettings.Key);

            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, request.Username)
                },
                expires: DateTime.UtcNow.AddHours(_jwtSettings.DurationInHours),
                signingCredentials: new SigningCredentials(
                    new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature));

            
            return tokenHandler.WriteToken(jwtSecurityToken);
        }
    }
}
