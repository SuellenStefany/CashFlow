using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using CashFlow.Transaction.Application.Interfaces;
using Microsoft.IdentityModel.Tokens;

namespace CashFlow.Transaction.Infrastructure.Authentication
{
    public  class AuthService : IAuthService
    {
        private readonly AuthSettings _authSettings;
        public AuthService(AuthSettings authSettings)
        {
            _authSettings = authSettings;
        }
        public string GenerateToken(Guid id)
        {
            var claims = new[]
            {
                new Claim("id", id.ToString()),
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authSettings.Key));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _authSettings.Issuer,
                audience: _authSettings.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_authSettings.ExpiryMinutes),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
