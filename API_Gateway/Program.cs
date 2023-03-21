using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Ocelot.Provider.Consul;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration.SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("Ocelot.json", false).Build();

//Ocelot
builder.Services.AddOcelot(configuration).AddConsul();

builder.Host.ConfigureLogging((context, logging) =>
{
    logging.AddConsole();
});

var app = builder.Build();

app.UseOcelot().Wait();

app.Run();
