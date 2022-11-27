using Anihithe.Discord.Bot.WowScout.Services;
using Anihithe.Wow.Api.Client;
using Anihithe.Wow.Api.Client.Services;
using Discord.Commands;
using Discord.Interactions;
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
            .AddDiscordCommandServiceConfig()
            .AddSingleton(configuration)
            // WowApiClient
            .AddSingleton<WowApiClient>()
            .AddTransient<ApiQueryService>()
            // Discord
            .AddSingleton<DiscordSocketClient>()
            .AddSingleton<CommandHandler>()
            .AddSingleton<LoggingService>()
            .AddTransient<EmbedService>()

            .AddSingleton(x => new InteractionService(x.GetRequiredService<DiscordSocketClient>()));

        return Task.FromResult<IServiceProvider>(services.BuildServiceProvider());
    }

    private static ServiceCollection AddDiscordSocketConfig(this ServiceCollection services)
    {
        var config = new DiscordSocketConfig {MessageCacheSize = 100};
        services.AddSingleton(config);
        return services;
    }

    private static ServiceCollection AddDiscordCommandServiceConfig(this ServiceCollection services)
    {
        var config = new CommandServiceConfig
        {
            CaseSensitiveCommands = false
        };
        services.AddSingleton(config);
        return services;
    }
}