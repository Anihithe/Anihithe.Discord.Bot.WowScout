using Anihithe.Discord.Bot.WowScout;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;

// TODO : Move Token in ENV varialbe.

class Program
{
    public static async Task Main(string[] args)
    {
        var configuration = ConfigurationBuilder.GetConfiguration();
        var services = await DependencyInjector.ConfigureServicesAsync(configuration);
        var client = services.GetRequiredService<DiscordSocketClient>();
        var log = services.GetRequiredService<LoggingService>();

        await client.LoginAsync(TokenType.Bot, configuration["Discord:Token"]);
        await client.StartAsync();

        client.Ready += () =>
        {
            Console.WriteLine("Bot is connected!");
            return Task.CompletedTask;
        };

        client.MessageReceived += MessageRecieved;
        client.MessageUpdated += MessageUpdated;

// Block this task until the program is closed.
        await Task.Delay(-1);

        Task MessageRecieved(SocketMessage msg)
        {
            if (!msg.Content.StartsWith("!")) return Task.CompletedTask;
            if (msg.Content.Contains("Topic"))
            {
                msg.Channel.SendMessageAsync(GetChannelTopic(msg.Channel.Id, client));
                return Task.CompletedTask;
            }

            msg.Channel.SendMessageAsync($"User {msg.Author.Username} successfull run command");

            return Task.CompletedTask;
        }

        async Task MessageUpdated(Cacheable<IMessage, ulong> msgBefore, SocketMessage msgAfter, ISocketMessageChannel channel)
        {
            var before = await msgBefore.GetOrDownloadAsync();
            await log.LogStringAsync($"{before} -> {msgAfter}");
        }

        string GetChannelTopic(ulong id, DiscordSocketClient client)
        {
            var channel = client.GetChannel(id) as SocketTextChannel;
            log.LogStringAsync($"{id} - {channel?.Topic}");
            return channel?.Topic ?? "empty";
        }

        SocketGuildUser GetGuildOwner(SocketChannel channel)
        {
            var guild = (channel as SocketGuildChannel)?.Guild;
            return guild?.Owner;
        }
    }
}