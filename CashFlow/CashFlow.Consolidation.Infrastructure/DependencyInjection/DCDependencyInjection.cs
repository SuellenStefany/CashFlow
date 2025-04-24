using CashFlow.Consolidation.Application.Interfaces;
using CashFlow.Consolidation.Application.Services;
using CashFlow.Consolidation.Infrastructure.Config;
using CashFlow.Consolidation.Infrastructure.Data;
using CashFlow.Consolidation.Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CashFlow.Consolidation.Infrastructure.DependencyInjection
{
    public static class DCDependencyInjection
    {
        public static IServiceCollection AddDCDependencyInjection(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<MongoDbSettings>(configuration.GetSection("MongoDbSettings"));
            services.AddSingleton<DCEntryContext>();

            services.AddScoped<IDCEntryRepository, DCEntryRepository>();
            services.AddScoped<IDCEntryService, DCEntryService>();

            return services;
        }   
    }
}
