using api.Services.Abstractions;
using api.Services.Concrete;
using api.Services.Features.Authentication;
using api.Services.Features.Sanctions;
using api.Services.Features.Users;

namespace api.Services;

public static class DependencyInjection
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddScoped<IAuthManager, AuthManager>();
        services.AddScoped<AuthService>();
        services.AddScoped<UserService>();
        services.AddScoped<SanctionService>();
        return services;
    }
}
