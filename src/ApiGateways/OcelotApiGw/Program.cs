using Ocelot.Cache.CacheManager;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);
builder.Host.ConfigureAppConfiguration(app => app.AddJsonFile($"ocelot.{System.Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json"));

//builder.Configuration.AddJsonFile($"ocelot.{System.Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json");
builder.Services.AddOcelot(builder.Configuration).AddCacheManager(settings => settings.WithDictionaryHandle());
var app = builder.Build();

app.UseOcelot().Wait();
app.MapGet("/", () => "Hello World!");



app.Run();