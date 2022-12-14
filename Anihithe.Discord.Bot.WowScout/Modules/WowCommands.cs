using Anihithe.Discord.Bot.WowScout.Services;
using Anihithe.Wow.Api.Client.Services;
using Discord.Interactions;

namespace Anihithe.Discord.Bot.WowScout.Modules;

[Group("wow", "wow commands")]
// interation modules must be public and inherit from an IInterationModuleBase
public class WowCommands : InteractionModuleBase<SocketInteractionContext>
{
    private CommandHandler _handler;
    private readonly ApiQueryService _apiQueryService;
    private readonly EmbedService _embedService;
    private readonly CheckProgress _checkProgress;

    // constructor injection is also a valid way to access the dependecies
    public WowCommands(CommandHandler handler, ApiQueryService apiQueryService, EmbedService embedService,
        CheckProgress checkProgress)
    {
        _handler = handler;
        _apiQueryService = apiQueryService;
        _embedService = embedService;
        _checkProgress = checkProgress;
    }

    // dependencies can be accessed through Property injection, public properties with public setters will be set by the service provider
    public InteractionService Commands { get; set; }

    [SlashCommand("get-test-progress", "get character test progress")]
    // ReSharper disable once UnusedMember.Global
    public async Task GetMyChar(string realm, string characterName)
    {
        var character = await _apiQueryService.GetRaidProgress(realm, characterName);

        var embed = _embedService.SimpleEmbed(character);

        await RespondAsync("", embed: embed);
    }

    [SlashCommand("get-my-raid-progress", "get character raid progress")]
    // ReSharper disable once UnusedMember.Global
    public async Task GetMyChara(string realm, string characterName)
    {
        var character = await _apiQueryService.GetRaidProgress(realm, characterName);

        var embed = _embedService.NoSoSimpleEmbed(character);

        await RespondAsync("", embed: embed);
    }

    [SlashCommand("start-check", "Start Check Progress")]
    // ReSharper disable once UnusedMember.Global
    public async Task StartCheck()
    {
        await _checkProgress.StartAutoCheck();
        await RespondAsync(await _checkProgress.GetStatusAutoCheck());
    }

    [SlashCommand("stop-check", "Stop Check Progress")]
    // ReSharper disable once UnusedMember.Global
    public async Task StopCheck()
    {
        await _checkProgress.StopAutoCheck();
        await RespondAsync(await _checkProgress.GetStatusAutoCheck());
    }

    [SlashCommand("status-check", "Get status Check Progress")]
    // ReSharper disable once UnusedMember.Global
    public async Task StatusCheck()
    {
        await RespondAsync(await _checkProgress.GetStatusAutoCheck());
    }

    [SlashCommand("add-character", "Add Character to autocheck")]
    // ReSharper disable once UnusedMember.Global
    public async Task AddCharacter(string realm, string characterName)
    {
        await _checkProgress.AddCharacter(realm, characterName);
        await RespondAsync($"Add {realm}-{characterName}");
    }
    
    [SlashCommand("get-characters", "Get autochecked characters")]
    // ReSharper disable once UnusedMember.Global
    public async Task GetCharacters()
    {
        await RespondAsync(await _checkProgress.GetCharacters());
    }
}