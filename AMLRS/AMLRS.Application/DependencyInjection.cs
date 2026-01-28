using AMLRS.Application.Interfaces;
using AMLRS.Application.Interfaces.Services;
using AMLRS.Application.Interfaces.Storage;
using AMLRS.Application.Services;
using AMLRS.Application.Storage;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace AMLRS.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationDI(this IServiceCollection services)
        {
            services.AddScoped<ICaseService, CaseService>();
            services.AddScoped<IDocumentService, DocumentService>();
            services.AddScoped<IFileStorage, LocalFileStorage>();
            return services;
        }
    }
}
