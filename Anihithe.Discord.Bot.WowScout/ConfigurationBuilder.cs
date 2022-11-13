using Microsoft.Extensions.Configuration;

namespace Anihithe.Discord.Bot.WowScout;

public static class ConfigurationBuilder
{
    public static IConfigurationRoot GetConfiguration()
    {
        var builder = new Microsoft.Extensions.Configuration.ConfigurationBuilder()
            .AddJsonFile("appsettings.json", false, true)
            .AddEnvironmentVariables();
        return builder.Build();
    }
}