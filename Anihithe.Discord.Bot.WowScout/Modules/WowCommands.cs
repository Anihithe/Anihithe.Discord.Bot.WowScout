using Anihithe.Discord.Bot.WowScout.Services;
using Discord.Interactions;

namespace Anihithe.Discord.Bot.WowScout.Modules;

[Group("wow","wow commands")]
// interation modules must be public and inherit from an IInterationModuleBase
public class WowCommands : InteractionModuleBase<SocketInteractionContext>
{
    // dependencies can be accessed through Property injection, public properties with public setters will be set by the service provider
    public InteractionService Commands { get; set; }
    private CommandHandler _handler;

    // constructor injection is also a valid way to access the dependecies
    public WowCommands(CommandHandler handler)
    {
        _handler = handler;
    }

    // our first /command!
    [SlashCommand("get-my-chars", "get character link to account")]
    public async Task EightBall(string accountname)
    {
        //https://eu.api.blizzard.com/profile/wow/character/elune/nealys/mythic-keystone-profile?namespace=profile-eu&locale=en_US&access_token=EUVVnGx40tnhTAvGSvCstpjBOfUGRAQnDd
        await RespondAsync($"not implemented yet");
    }
}