using System.Diagnostics;
using Anihithe.Wow.Api.Client.Models.Reworked;
using Anihithe.Wow.Api.Client.Services;

namespace Anihithe.Discord.Bot.WowScout.Services;

public static class CheckProgress
{
    private static bool _process;

    private static DateTimeOffset _lastCheck;

    private static readonly ApiQueryService _apiQueryService;
    // Memo:
    // API clients are limited to 36,000 requests per hour at a rate of 100 requests per second.
    // Exceeding the hourly quota results in slower service until traffic decreases.
    // Exceeding the per-second limit results in a 429 error for the remainder of the second until the quota refreshes.


    static CheckProgress()
    {
        _apiQueryService = new ApiQueryService();
        _lastCheck = DateTimeOffset.Now;
    }

    public static Task StartAutoCheck()
    {
        _process = true;
        AutoCheck();
        return Task.CompletedTask;
    }

    public static Task StopAutoCheck()
    {
        _process = false;
        return Task.CompletedTask;
    }

    public static Task<string> GetStatusAutoCheck()
    {
        return Task.FromResult(_process ? "Running" : "Stopped");
    }

    private static async Task AutoCheck()
    {
        while (_process)
        {
            ProcessCheck();
            await Task.Delay(TimeSpan.FromMinutes(2));
        }
    }

    private static async Task ProcessCheck()
    {
        Console.WriteLine($"{DateTime.Now} - ProcessCheck");
        var players = new[] {"nealys", "llaria", "berdol", "titenenette"};
        foreach (var player in players)
        {
            try
            {
                Console.WriteLine($"{player}");
                var result = await _apiQueryService.GetRaidProgress("elune", player);
                Console.WriteLine($"{result.Character.Name}");
                var val = new AutoCheck(result);
                Console.WriteLine($"{val.encounters.Count}");
                var newKills = val.encounters.Where(x => x.LastKillTimeStamp >= _lastCheck && x.KillCount == 1);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
        }
    }
}