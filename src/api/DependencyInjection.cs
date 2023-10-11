using System.Text;
using api.Data;
using api.Middlewares;
using api.Services;
using api.Services.Settings;
using api.Utilities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
namespace api;

public static class DependencyInjection
{
    public static IServiceCollection RegisterServices(
        this IServiceCollection services,
        IConfiguration configuration,
        IHostEnvironment env)
    {
        services.AddAuth(configuration);
        services.AddServices();
        services.AddPersistence(configuration, env);
        services.AddControllers();
        services.AddCors();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(c => {
            c.SwaggerDoc("v1", new OpenApiInfo{
                Title = "SMS_API",
                Version = "v1"
            });
            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme(){
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer",
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Description = "JWT Authorization header using Bearer scheme.\r\n\r\n Enter. 'Bearer' [space] and then your token in the text input below. \r\n\r\nExample: \"Bearer 1safsfdfsdfsdf"
            });
        });
        services.AddScoped<RegisterUserIdMiddleware>();
        services.AddScoped<VerifyExistenceMiddleware>();
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly));
        return services;
    }

    private static IServiceCollection AddAuth(this IServiceCollection services, IConfiguration cfg)
    {
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(opt =>
            {
                JwtSettings jwtSettings = cfg.GetRequiredSection(JwtSettings.SectionName).Get<JwtSettings>()!;
                opt.TokenValidationParameters = new TokenValidationParameters()
                {
                    ClockSkew = TimeSpan.Zero,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    ValidIssuer = jwtSettings.Issuer,
                    ValidAudience = jwtSettings.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.SecretKey))
                };
            });

        services.AddAuthorization(opt =>
        {
            opt.AddPolicy(Policies.AdminOnly, p => p.RequireRole(Roles.Admin));
            opt.AddPolicy(Policies.SecretaryOnly, p => p.RequireRole(Roles.Secretary));
            opt.AddPolicy(Policies.StudentOnly, p => p.RequireRole(Roles.Student));
            opt.AddPolicy(Policies.AdminAndSecretary, p => p.RequireRole(Roles.Admin, Roles.Secretary));
        });

        return services;
    }

    public static WebApplication ConfigurePipeline(this WebApplication app)
    {
        app.UseSwagger();
        app.UseSwaggerUI();

        app.UseCors(cfg =>
        {
            cfg.AllowAnyOrigin();
        });

        // app.UseHttpsRedirection();

        app.UseAuthorization();

        app.UseMiddleware<RegisterUserIdMiddleware>();

        app.UseMiddleware<VerifyExistenceMiddleware>();

        app.MapControllers();

        return app;
    }
}
