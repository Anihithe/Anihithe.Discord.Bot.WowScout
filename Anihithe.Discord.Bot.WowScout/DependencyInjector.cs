using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Anihithe.Discord.Bot.WowScout;

public static class DependencyInjector
{
    public static Task<IServiceProvider> ConfigureServicesAsync(IConfigurationRoot configuration)
    {
        var services = new ServiceCollection();
        services
            .AddDiscordSocketConfig()
            .AddSingleton(configuration)
            .AddSingleton<DiscordSocketClient>()
            .AddSingleton<CommandService>()
            .AddSingleton<LoggingService>();

        return Task.FromResult<IServiceProvider>(services.BuildServiceProvider());
    }
    
    private static ServiceCollection AddDiscordSocketConfig(this ServiceCollection services)
    {
        var config = new DiscordSocketConfig {MessageCacheSize = 100};
        services.AddSingleton(config);
        return services;
    }
    
    // private static ServiceCollection AddLoggin(this ServiceCollection services)
    // {
    //     var 
    // }
}