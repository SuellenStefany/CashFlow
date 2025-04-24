using CashFlow.Transaction.Application.Interfaces;
using CashFlow.Transaction.Application.Services;
using CashFlow.Transaction.Infrastructure.Authentication;
using CashFlow.Transaction.Infrastructure.Config;
using CashFlow.Transaction.Infrastructure.Data;
using CashFlow.Transaction.Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CashFlow.Transaction.Infrastructure.DependencyInjection
{
    public static class DCDependencyInjection
    {
        public static IServiceCollection AddConnection(this IServiceCollection services,IConfiguration configuration)
        {
            services.Configure<MongoDbSettings>(configuration.GetSection("MongoDbSettings"));
            services.AddSingleton<DCEntryContext>();

            services.AddScoped<IDebitEntryRepository, DebitEntryRepository>();
            services.AddScoped<IDebitEntryService, DebitEntryService>();

            services.AddScoped<ICreditEntryRepository, CreditEntryRepository>();
            services.AddScoped<ICreditEntryService, CreditEntryService>();

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();

            services.AddScoped<IPasswordHasher, AuthHashPassword>();
            services.AddScoped<IAuthService, AuthService>();
            return services;
        }
    }
}
