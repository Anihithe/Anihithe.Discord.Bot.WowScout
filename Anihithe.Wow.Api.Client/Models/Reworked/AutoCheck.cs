using Anihithe.Wow.Api.Client.Models.ProfileApi;

namespace Anihithe.Wow.Api.Client.Models.Reworked;

public class AutoCheck
{
    public readonly string PlayerName;
    public List<EncounterProgress> encounters;

    public AutoCheck(DtoRoot root)
    {
        PlayerName = root.Character.Name;
        encounters = new List<EncounterProgress>();
        foreach (var expansion in root.Expansions)
        {
            foreach (var instance in expansion.Instances)
            {
                foreach (var mode in instance.Modes)
                {
                    foreach (var encounter in mode.Progress.Encounters)
                    {
                        var encounterProgress = new EncounterProgress
                        {
                            ModeName = mode.Difficulty.Name,
                            RaidName = instance.Instance.Name,
                            BossName = encounter.Encounter.Name,
                            KillCount = encounter.CompletedCount,
                            LastKillTimeStamp = DateTimeOffset.FromUnixTimeMilliseconds((long)encounter.LastKillTimestamp)
                        };
                        encounters.Add(encounterProgress);
                    }
                }
            }
        }
    }
}