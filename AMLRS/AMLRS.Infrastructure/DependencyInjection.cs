using AMLRS.Application.Interfaces.Log;
using AMLRS.Core.Abstraction.Reposotory;
using AMLRS.Core.Abstraction.Reposotory.User;
using AMLRS.Core.Options;
using AMLRS.Infrastructure.Data;
using AMLRS.Infrastructure.Logging;
using AMLRS.Infrastructure.Repositories.User;
using AMLRS.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Serilog;

namespace AMLRS.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureDI(this IServiceCollection services)
        {
            services.AddDbContext<AmlDbContext>((provider, options) =>
                options.UseSqlServer(provider.GetRequiredService<IOptionsSnapshot<ConnectionStringOptions>>().Value.DevCS,
                    b => b.MigrationsAssembly(typeof(AmlDbContext).Assembly.FullName)
                ));

            services.AddScoped<ICaseRepository, CaseRepository>();
            services.AddScoped<IDocumentRepository, DocumentRepository>();
            services.AddSingleton<ILogger>(Log.Logger);
            services.AddScoped<IAuditLogger, SerilogAuditLogger>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserInviteRepository, UserInviteRepository>();
            services.AddScoped<IOtpRepository, OtpRepository>();
            services.AddScoped<IOrganisationRepository, OrganisationRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }

    }
}
