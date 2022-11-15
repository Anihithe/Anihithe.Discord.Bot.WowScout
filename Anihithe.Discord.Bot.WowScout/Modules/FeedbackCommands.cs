using Anihithe.Discord.Bot.WowScout.Services;
using Discord.Interactions;

namespace Anihithe.Discord.Bot.WowScout.Modules;

public class FeedbackCommands : InteractionModuleBase<SocketInteractionContext>
{
    public enum Rating
    {
        Terrible,
        Meh,
        Good,
        Lovely,
        Excelent
    }

    private readonly CommandHandler _handler;

    public FeedbackCommands(CommandHandler handler)
    {
        _handler = handler;
    }

    [SlashCommand("feedback", "Tell us how much you are enjoying this bot!")]
    public async Task Feedback(Rating choice)
    {
        await RespondAsync($"u make a choice : {choice.ToString()}");
    }
}