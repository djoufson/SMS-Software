using api.Services.Abstractions;
using api.Services.Authentication;
using api.Services.Concrete;

namespace api.Services;

public static class DependencyInjection
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddScoped<AuthService>();
        return services;
    }
}
