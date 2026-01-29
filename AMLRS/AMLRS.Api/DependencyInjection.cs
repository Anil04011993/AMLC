using AMLRS.Application;
using AMLRS.Core;
using AMLRS.Core.Domains.Email.Entities.AMLRS.Application.Settings;
using AMLRS.Infrastructure;
namespace AMLRS.Api
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddAppDI(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddApplicationDI().AddInfrastructureDI().AddCoreDI(configuration);
            
            return services;
        }
    }
}
