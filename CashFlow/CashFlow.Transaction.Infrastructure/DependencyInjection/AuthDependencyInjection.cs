using System.Text;
using CashFlow.Transaction.Infrastructure.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace CashFlow.Transaction.Infrastructure.DependencyInjection
{
    public static class AuthDependencyInjection
    {
        public static IServiceCollection AddAuthenticationJwt(this IServiceCollection services, IConfiguration config)
        {
            var authSettings = new AuthSettings();
            config.GetSection("AuthSettings").Bind(authSettings);

            services.AddSingleton(authSettings);
            services.AddSingleton<AuthService>();

            var key = Encoding.UTF8.GetBytes(authSettings.Key);

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = authSettings.Issuer,
                        ValidAudience = authSettings.Audience,
                        IssuerSigningKey = new SymmetricSecurityKey(key)
                    };
                });

            services.AddAuthorization();

            return services;
        }
    }
}
