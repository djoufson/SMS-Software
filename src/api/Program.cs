using api;
var builder = WebApplication.CreateBuilder(args);

builder.Services.RegisterServices(builder.Configuration);

var app = builder.Build();

app.ConfigurePipeline();

await app.RunAsync();
