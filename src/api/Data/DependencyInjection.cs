using Microsoft.EntityFrameworkCore;

namespace api.Data;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection services)
    {
        services.AddDbContext<AppDbContext>(cfg => cfg.UseSqlite("Data Source=Database/app.db"));
        return services;
    }
}
