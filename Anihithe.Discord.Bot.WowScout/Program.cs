using Anihithe.Discord.Bot.WowScout;
using Discord;
using Discord.Commands;
using Discord.WebSocket;

// TODO : Move Token in ENV varialbe.

class Program
{

    public static async Task Main(string[] args)
    {
        var configuration = ConfigurationBuilder.GetConfiguration();
        var token = "";
        var _config = new DiscordSocketConfig {MessageCacheSize = 100};
        var _client = new DiscordSocketClient(_config);
        var _command = new CommandService();
        var _log = new LoggingService(_client, _command);

        await _client.LoginAsync(TokenType.Bot, token);
        await _client.StartAsync();

        _client.Ready += () =>
        {
            Console.WriteLine("Bot is connected!");
            return Task.CompletedTask;
        };

        _client.MessageReceived += MessageRecieved;
        _client.MessageUpdated += MessageUpdated;

// Block this task until the program is closed.
        await Task.Delay(-1);

        Task MessageRecieved(SocketMessage msg)
        {
            if (!msg.Content.StartsWith("!")) return Task.CompletedTask;
            if (msg.Content.Contains("Topic"))
            {
                msg.Channel.SendMessageAsync(GetChannelTopic(msg.Channel.Id, _client));
                return Task.CompletedTask;
            }

            msg.Channel.SendMessageAsync($"User {msg.Author.Username} successfull run command");

            return Task.CompletedTask;
        }

        async Task MessageUpdated(Cacheable<IMessage, ulong> msgBefore, SocketMessage msgAfter, ISocketMessageChannel channel)
        {
            var before = await msgBefore.GetOrDownloadAsync();
            _log.LogAsync(new LogMessage(LogSeverity.Info, "MessageUpdated", $"{before} -> {msgAfter}"));
        }

        string GetChannelTopic(ulong id, DiscordSocketClient client)
        {
            var channel = client.GetChannel(id) as SocketTextChannel;
            _log.LogAsync(new LogMessage(LogSeverity.Info, nameof(GetChannelTopic), $"{id} - {channel?.Topic}"));
            return channel?.Topic ?? "empty";
        }

        SocketGuildUser GetGuildOwner(SocketChannel channel)
        {
            var guild = (channel as SocketGuildChannel)?.Guild;
            return guild?.Owner;
        }
    }
}