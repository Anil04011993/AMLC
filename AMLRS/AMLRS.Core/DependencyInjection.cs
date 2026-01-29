using AMLRS.Core.Domains.Email.Entities.AMLRS.Application.Settings;
using AMLRS.Core.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AMLRS.Core
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddCoreDI(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<ConnectionStringOptions>(configuration.GetSection(ConnectionStringOptions.SectionName));
            services.Configure<GmailSettings>(configuration.GetSection("Gmail"));

            return services;
        }
    }
}
