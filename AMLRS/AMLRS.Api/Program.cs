using AMLRS.Api;
using AMLRS.Api.Middleware;
using AMLRS.Api.Middleware.AMLRS.Api.Middleware;
using AMLRS.Application.DTOs;
using AMLRS.Application.Interfaces.Services.User;
using AMLRS.Application.Services.User;
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
app.UseStatusCodePages(async context =>
{
    var response = context.HttpContext.Response;

    if (response.HasStarted)
        return;

    response.ContentType = "application/json";

    var apiResponse = new ApiResponse<object>
    {
        StatusCode = response.StatusCode,
        Message = response.StatusCode switch
        {
            StatusCodes.Status401Unauthorized => "Unauthorized",
            StatusCodes.Status403Forbidden => "Forbidden",
            StatusCodes.Status404NotFound => "Resource not found",
            _ => "Request failed"
        },
        Data = null
    };

    await response.WriteAsJsonAsync(apiResponse);
});

// 2. CorrelationId enrichment middleware (HERE)
app.UseMiddleware<CorrelationIdMiddleware>();

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
