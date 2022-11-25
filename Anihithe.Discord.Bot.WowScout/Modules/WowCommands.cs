using Anihithe.Discord.Bot.WowScout.Services;
using Anihithe.Wow.Api.Client.Services;
using Discord;
using Discord.Interactions;

namespace Anihithe.Discord.Bot.WowScout.Modules;

[Group("wow", "wow commands")]
// interation modules must be public and inherit from an IInterationModuleBase
public class WowCommands : InteractionModuleBase<SocketInteractionContext>
{
    private CommandHandler _handler;

    // constructor injection is also a valid way to access the dependecies
    public WowCommands(CommandHandler handler)
    {
        _handler = handler;
    }

    // dependencies can be accessed through Property injection, public properties with public setters will be set by the service provider
    public InteractionService Commands { get; set; }

    [SlashCommand("get-my-raid-progress", "get character raid progress")]
    public async Task GetMyChar(string realm, string characterName)
    {
        var a = new ApiQueryService();
        var character = await a.GetRaidProgress(realm, characterName);
        
        var embed = new EmbedBuilder
        {
            Color = Color.Teal,
            Description = "New Legend is born !"
        };

        embed.AddField("Player", character?.Character.Name, true)
            .AddField("Boss",
                character?.Expansions?.First().Instances.First().Modes.First().Progress.Encounters.First().Encounter.Name, true);

        await RespondAsync("", embed: embed.Build());
    }
}