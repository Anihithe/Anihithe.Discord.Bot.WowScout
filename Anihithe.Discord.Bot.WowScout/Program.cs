using Anihithe.Discord.Bot.WowScout.Services;
using Anihithe.Wow.Api.Client;
using Anihithe.Wow.Api.Client.Services;
using Discord;
using Discord.Interactions;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;

namespace Anihithe.Discord.Bot.WowScout;

internal static class Program
{
    public static async Task Main(string[] args)
    {
        var configuration = ConfigurationBuilder.GetConfiguration();
        var services = await DependencyInjector.ConfigureServicesAsync(configuration);
        var client = services.GetRequiredService<DiscordSocketClient>();
        var logging = services.GetRequiredService<LoggingService>();
        var commands = services.GetRequiredService<InteractionService>();
        var wowApiClient = services.GetRequiredService<WowApiClient>();
        await services.GetRequiredService<CommandHandler>().InitializeAsync();
        
        await wowApiClient.Config(configuration["Wow:ClientId"]!, configuration["Wow:ClientSecret"]!);
        await wowApiClient.GetToken();
        
        await client.LoginAsync(TokenType.Bot, configuration["Discord:Token"]);
        await client.StartAsync();

        client.Ready += ClientReady;

        // Block this task until the program is closed.
        await Task.Delay(-1);

        async Task ClientReady()
        {
            //var a = client.GetChannel(1003246265510928384) as IMessageChannel;
            //a.SendMessageAsync("i'm online");

            await commands.RegisterCommandsGloballyAsync();
        }
    }
}