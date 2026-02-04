using AMLRS.Application.Interfaces.Services;
using AMLRS.Application.Interfaces.Services.User;
using AMLRS.Application.Interfaces.Storage;
using AMLRS.Application.Services;
using AMLRS.Application.Services.User;
using AMLRS.Application.Storage;
using Microsoft.Extensions.DependencyInjection;

namespace AMLRS.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationDI(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ICaseService, CaseService>();
            services.AddScoped<IDocumentService, DocumentService>();
            services.AddScoped<IFileStorage, LocalFileStorage>();

            services.AddScoped<IOrganisationService, OrganisationService>();
            services.AddScoped<ISignupService, SignupService>();
          
            // Register SES client
            //services.AddAWSService<IAmazonSimpleEmailService>();

            // Register your email sender
            //services.AddScoped<IEmailSender, SesEmailSender>();

            services.AddScoped<IUserInviteService, UserInviteService>();
            services.AddScoped<IEmailSender, GmailEmailSender>();
            services.AddScoped<IEmailSender, GmailEmailSender>();

            return services;
        }
    }
}
