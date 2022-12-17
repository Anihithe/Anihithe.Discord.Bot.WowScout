using System.Text;
using Anihithe.Discord.Bot.WowScout.Models;
using Anihithe.Wow.Api.Client.Models.Reworked;
using Anihithe.Wow.Api.Client.Services;
using Discord;
using Discord.WebSocket;

namespace Anihithe.Discord.Bot.WowScout.Services;

public class CheckProgress
{
    private bool _process;

    private DateTimeOffset _lastCheck;

    private readonly ApiQueryService _apiQueryService;

    private readonly DiscordSocketClient _client;

    private readonly EmbedService _embedService;

    private readonly List<CharacterData> _charactersTracked;
    // Memo:
    // API clients are limited to 36,000 requests per hour at a rate of 100 requests per second.
    // Exceeding the hourly quota results in slower service until traffic decreases.
    // Exceeding the per-second limit results in a 429 error for the remainder of the second until the quota refreshes.


    public CheckProgress(ApiQueryService apiQueryService, DiscordSocketClient client, EmbedService embedService)
    {
        _apiQueryService = apiQueryService;
        _client = client;
        _embedService = embedService;
        _lastCheck = DateTimeOffset.Now;
        _charactersTracked = new List<CharacterData>();
    }

    public Task StartAutoCheck()
    {
        _process = true;
        AutoCheck();
        return Task.CompletedTask;
    }

    public Task StopAutoCheck()
    {
        _process = false;
        return Task.CompletedTask;
    }

    public Task<string> GetStatusAutoCheck()
    {
        return Task.FromResult(_process ? "Running" : "Stopped");
    }

    private async Task AutoCheck()
    {
        while (_process)
        {
            ProcessCheck();
            await Task.Delay(TimeSpan.FromMinutes(1));
        }
    }

    public async Task AddCharacter(string realm, string name)
    {
        var character = await _apiQueryService.GetRaidProgress(realm, name);
        _charactersTracked.TryAdd(character);
    }

    public async Task<string> GetCharacters()
    {
        var characters = new StringBuilder();
        foreach (var characterData in _charactersTracked)
        {
            characters.AppendLine($"{characterData.Realm}-{characterData.Name}");
        }

        return characters.ToString();
    }

    private async Task ProcessCheck()
    {
        Console.WriteLine($"{DateTime.Now} - ProcessCheck");
        var embed = new EmbedBuilder()
            .WithColor(Color.Teal)
            .WithDescription("New Kill !");
        foreach (var character in _charactersTracked)
        {
            try
            {
                var result = await _apiQueryService.GetRaidProgress(character.Realm, character.Name);
                var val = new AutoCheck(result);
                var kills = val.encounters.Where(x => x.LastKillTimeStamp > character.Lastkilldatetime).ToList();
                val.encounters = kills;
                if (val.encounters.Count <= 0) continue;

                character.Lastkilldatetime = val.encounters.Max(x => x.LastKillTimeStamp);
                await _client
                    .GetGuild(1003246175786385508)
                    .GetTextChannel(1003246265510928384)
                    .SendMessageAsync("", embed: _embedService.NotSoSimpleProgressEmbed(val, embed));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}