﻿using System.Reflection;
using System.Text;
using Itis.Playhost.Api.PostgreSql;
using Itis.Playhost.Api.Core.Abstractions;
using Itis.Playhost.Api.Core.Entities;
using Itis.Playhost.Api.Core.Services;
using Itis.Playhost.Api.Web.Configurators;
using Itis.Playhost.Api.Web.Constants;
using Itis.Playhost.Api.Web.Middlewares;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace Itis.Playhost.Api.Web.Extensions;

/// <summary>
/// Класс с расширениями для <see cref="WebApplicationBuilder"/>
/// </summary>
public static class WebApplicationBuilderExtensions
{
    /// <summary>
    /// Создание и настройка подключения к бд
    /// </summary>
    /// <param name="builder">WebApplicationBuilder</param>
    public static void ConfigurePostgresqlConnection(this WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<EfContext>(
            options =>
            {
                options.UseNpgsql(
                    builder.Configuration["Application:DbConnectionString"],
                    opt =>
                    {
                        opt.MigrationsAssembly(typeof(EfContext).GetTypeInfo().Assembly.GetName().Name);
                        opt.EnableRetryOnFailure(
                            15,
                            TimeSpan.FromSeconds(30),
                            null);
                    });
            });
    }
    
    /// <summary>
    /// Добавить службы и зависимости проекта
    /// </summary>
    /// <param name="builder">WebApplicationBuilder</param>
    public static void ConfigureCore(this WebApplicationBuilder builder)
    {
        builder.Services.AddMediatR(typeof(EntityBase).Assembly);
        
        builder.Services.AddScoped<IDbContext, EfContext>();
        builder.Services.AddScoped<IUserService, UserService>();
        builder.Services.AddSingleton<IJwtService, JwtService>();
        builder.Services.AddScoped<IRoleService, RoleService>();
        builder.Services.AddScoped<IEmailSenderService, EmailSenderService>();
        builder.Services
            .AddIdentity<User, Role>(opt =>
            {
                opt.Password.RequiredLength = 6;
                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequireDigit = false;
            })
            .AddEntityFrameworkStores<EfContext>()
            .AddUserManager<UserManager<User>>()
            .AddSignInManager<SignInManager<User>>()
            .AddDefaultTokenProviders();
        builder.Services.Configure<DataProtectionTokenProviderOptions>(options =>
            options.TokenLifespan = TimeSpan.FromMinutes(5));
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddCustomSwagger();
        builder.Services.AddCors(options =>
        {
            options.AddPolicy(name: SpecificOrigins.MyAllowSpecificOrigins, 
                builder =>
                {
                    builder
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowAnyOrigin()
                        .SetIsOriginAllowedToAllowWildcardSubdomains();
                });
        });
        builder.Services.AddSignalR();
    }

    /// <summary>
    /// Добавить и настроить авторизацию
    /// </summary>
    /// <param name="builder">WebApplicationBuilder</param>
    public static void ConfigureAuthorization(this WebApplicationBuilder builder)
    {
        builder.Services
            .AddAuthorization(
                opt =>
                {
                    opt.DefaultPolicy = 
                        new AuthorizationPolicyBuilder(JwtBearerDefaults.AuthenticationScheme)
                        .RequireAuthenticatedUser()
                        .Build();
                    opt.PolicyConfigure();
                });
    }

    /// <summary>
    /// Подключение и настройка JwtBearer
    /// </summary>
    /// <param name="builder">WebApplicationBuilder</param>
    public static void ConfigureJwtBearer(this WebApplicationBuilder builder)
    {
        var issuer = builder.Configuration["JwtSettings:Issuer"];
        var audience = builder.Configuration["JwtSettings:Audience"];
        var secretKey = builder.Configuration["JwtSettings:SecretKey"]!;

        var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
        
        builder.Services
            .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidIssuer = issuer,
                    ValidateAudience = false,
                    ValidAudience = audience,
                    ValidateLifetime = true,
                    IssuerSigningKey = signingKey,
                    ValidateIssuerSigningKey = true,
                };
            });
    }
    
    private static IServiceCollection AddCustomSwagger(this IServiceCollection services)
        => services
            .AddSwaggerGen(c =>
            {
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer",
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header,
                        },
                        new List<string>()
                    }
                });
            });
    
    /// <summary>
    /// Использовать обработчик исключений.
    /// </summary>
    /// <param name="builder">Билдер пайплайна ASP.NET Core</param>
    /// <returns></returns>
    public static IApplicationBuilder UseExceptionHandling(this IApplicationBuilder builder)
        => builder.UseMiddleware<ExceptionHandlingMiddleware>();
}