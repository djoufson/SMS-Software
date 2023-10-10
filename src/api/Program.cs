using api;
using api.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.RegisterServices(builder.Configuration);

var app = builder.Build();

await app.SeedRolesAsync();

await app.ConfigurePipeline();

await app.RunAsync();
