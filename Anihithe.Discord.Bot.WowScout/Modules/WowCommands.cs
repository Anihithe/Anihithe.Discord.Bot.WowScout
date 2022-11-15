using System.Net;
using Anihithe.Discord.Bot.WowScout.Models;
using Anihithe.Discord.Bot.WowScout.Services;
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

    [SlashCommand("get-my-char", "get character detail")]
    public async Task GetMyChar(string realm, string characterName)
    {
        var client = new HttpClient();
        var uri = new Uri(
            $"https://eu.api.blizzard.com/profile/wow/character/{realm}/{characterName}?namespace=profile-eu&locale=fr_FR&access_token={BlizzardOAuth2.wowToken.accessToken}");
        var response = await client.GetAsync(uri);
        var result = await response.Content.ReadAsStringAsync();
        var character = JsonConvert.DeserializeObject<CharacterModel>(result);
        await RespondAsync(character?.ToString() ?? "not found");
    }
}