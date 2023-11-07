using api;
using api.Data;
using api.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.RegisterServices(builder.Configuration, builder.Environment);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.MapControllers();

app.Run();

await app.PrepDatabase();

await app.SeedRolesAsync();

await app.SeedDataAsync();

app.UseMiddleware<CorsMiddleware>();

app.ConfigurePipeline();

await app.RunAsync();
