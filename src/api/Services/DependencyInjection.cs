using api.Services.Abstractions;
using api.Services.Concrete;
using api.Services.Features.Authentication;
using api.Services.Features.Sanctions;
using api.Services.Features.Users;
using api.Settings;

namespace api.Services;

public static class DependencyInjection
{
    public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration cfg)
    {
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddSingleton<IHashGenerator, HashGenerator>();
        services.AddSingleton(cfg.GetRequiredSection(HashSettings.SectionName).Get<HashSettings>()!);
        services.AddScoped<IAuthManager, AuthManager>();
        services.AddScoped<AuthService>();
        services.AddScoped<UserService>();
        services.AddScoped<SanctionService>();
        return services;
    }
}
