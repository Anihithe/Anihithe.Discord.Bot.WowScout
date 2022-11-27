namespace Anihithe.Wow.Api.Client.Models.Reworked;

public class EncounterProgress
{
    public EncounterProgress() { }

    public string BossName { get; set; }
    public string RaidName { get; set; }
    public string ModeName { get; set; }
    public int KillCount { get; set; }
    public DateTimeOffset LastKillTimeStamp { get; set; }
}