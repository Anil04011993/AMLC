using AMLRS.Api;
using AMLRS.Api.Middleware;
using AMLRS.Api.Middleware.AMLRS.Api.Middleware;
using AMLRS.Application.Interfaces.Services;
using AMLRS.Application.Services;
using AMLRS.Core.Abstraction.Reposotory;
using AMLRS.Infrastructure.Logging;
using AMLRS.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

SerilogConfiguration.Configure(builder.Configuration);
//// Load AWS options from config
//builder.Services.AddDefaultAWSOptions(
//    builder.Configuration.GetAWSOptions());

builder.Host.UseSerilog();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAppDI(builder.Configuration);

// Register core application services (ensure controllers can resolve dependencies)
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddOpenApi();

builder.Services.AddCors(options =>
{
    options.AddPolicy("FrontendOnly", policy =>
    {
        policy
            .WithOrigins(
                "https://app.yourdomain.com",
                "http://localhost:5173"
            )
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

var app = builder.Build();

//Correct order:
//Exception handling
//CorrelationId enrichment
//Authentication
//Authorization
//Request logging
//Endpoints
// 1. Exception handling (FIRST)
app.UseMiddleware<ExceptionHandlingMiddleware>();

// 2. CorrelationId enrichment middleware (HERE)
app.UseMiddleware<CorrelationIdMiddleware>();

// 3. Other middleware
//app.UseHttpsRedirection();
//app.UseAuthentication();
//app.UseAuthorization();

// 4. Request logging (after enrichment)
//app.UseSerilogRequestLogging();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("FrontendOnly");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
