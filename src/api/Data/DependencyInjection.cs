using api.Entities;
using api.Entities.Base;
using api.Entities.ValueObjects;
using api.Services.Abstractions;
using api.Utilities;
using Microsoft.EntityFrameworkCore;

namespace api.Data;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection services)
    {
        services.AddDbContext<AppDbContext>(cfg => cfg.UseSqlite("Data Source=Database/app.db"));
        return services;
    }

    public static async Task<WebApplication> SeedDataAsync(this WebApplication app)
    {
        var scope = app.Services.CreateAsyncScope();
        var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        var authManager = scope.ServiceProvider.GetRequiredService<IAuthManager>();
        if(await db.Users.AnyAsync())
            return app;

        var user = Admin.Create("Admin", "Admin", Email.Create("admin@email.com")!, Password.CreateNewPassword("string")!, "", "", "", "", "", "", "");

        await authManager.AddToRoleAsync(user, Roles.Admin);

        await db.Users.AddAsync(user);

        await db.SaveChangesAsync();
        return app;
    }

    public static async Task<WebApplication> SeedRolesAsync(this WebApplication app)
    {
        var scope = app.Services.CreateAsyncScope();
        var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        if(await db.Roles.AnyAsync())
            return app;

        var roles = new Role[]
        {
            Role.CreateNewRole(Roles.Admin),
            Role.CreateNewRole(Roles.SuperAdmin),
            Role.CreateNewRole(Roles.Secretary),
            Role.CreateNewRole(Roles.Student),
            Role.CreateNewRole(Roles.Parent),
        };

        await db.AddRangeAsync(roles);
        await db.SaveChangesAsync();
        return app;
    }
}
