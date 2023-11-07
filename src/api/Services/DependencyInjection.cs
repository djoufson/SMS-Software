using api.Features.Authentication;
using api.Features.Sanctions;
using api.Features.Users;
using api.Services.Concrete;
using api.Services.Interfaces;
using api.Settings;

namespace api.Services;

public static class DependencyInjection
{
    public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration cfg)
    {
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddSingleton<IHashGenerator, HashGenerator>();
        services.AddSingleton(cfg.GetRequiredSection(HashSettings.SectionName).Get<HashSettings>()!);
        services.AddSingleton(cfg.GetRequiredSection(JwtSettings.SectionName).Get<JwtSettings>()!);
        services.AddScoped<IRolesManager, RolesManager>();
        services.AddScoped<AuthService>();
        services.AddScoped<UserService>();
        services.AddScoped<SanctionService>();
        return services;
    }
}
