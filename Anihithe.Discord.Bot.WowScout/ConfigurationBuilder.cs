using Discord;
using Discord.WebSocket;
using Microsoft.Extensions.Configuration;

namespace Anihithe.Discord.Bot.WowScout;

public static class ConfigurationBuilder
{
    public static IConfigurationRoot GetConfiguration()
    {
        var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
        var builder = new Microsoft.Extensions.Configuration.ConfigurationBuilder()
            .AddJsonFile("appsettings.json", false, true)
            .AddJsonFile($"appsettings.{env}.json", false, true)
            .AddEnvironmentVariables();
        return builder.Build();
    }
}