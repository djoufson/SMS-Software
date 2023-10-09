using api.Entities;
using Microsoft.EntityFrameworkCore;

namespace api.Data;

public sealed class AppDbContext : DbContext
{
    public DbSet<Admin> Admins { get; set; }
    public DbSet<Parent> Parents { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Sanction> Sanctions { get; set; }
    public DbSet<Secretary> Secretaries { get; set; }
    public DbSet<Student> Students { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}
