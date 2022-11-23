using Anihithe.Discord.Bot.WowScout.Services;
using Anihithe.Wow.Api.Client.Models;
using Discord.Interactions;
using Newtonsoft.Json;

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
        var client = new HttpClient();
        var uri = new Uri(
            $"https://eu.api.blizzard.com/profile/wow/character/{realm}/{characterName}/encounters/raids?namespace=profile-eu&locale=fr_FR&access_token={BlizzardOAuth2.Token.accessToken}");
        var response = await client.GetAsync(uri);
        var result = await response.Content.ReadAsStringAsync();
        var character = JsonConvert.DeserializeObject<RaidApi>(result);
        await RespondAsync(character?.ToString() ?? "not found");
    }
}