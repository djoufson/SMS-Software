using Api;
var builder = WebApplication.CreateBuilder(args);

builder.Services.RegisterServices();

var app = builder.Build();

app.ConfigurePipeline();

await app.RunAsync();
