using Discord;
using Discord.Commands;
using Discord.Interactions;
using Discord.WebSocket;

namespace Anihithe.Discord.Bot.WowScout.Services;

public class LoggingService
{
    public LoggingService(DiscordSocketClient client, InteractionService interaction)
    {
        client.Log += LogAsync;
        interaction.Log += LogAsync;
    }

    public Task LogStringAsync(string message)
    {
        return LogAsync(new LogMessage(LogSeverity.Info, "Custom", message));
    }

    private Task LogAsync(LogMessage message)
    {
        if (message.Exception is CommandException cmdException)
        {
            Console.WriteLine($"[Command/{message.Severity}] {cmdException.Command.Aliases.First()}"
                              + $" failed to execute in {cmdException.Context.Channel}.");
            Console.WriteLine(cmdException);
        }
        else 
            Console.WriteLine($"[General/{message.Severity}] {message}");

        return Task.CompletedTask;
    }
}