using System.Text;
using Anihithe.Wow.Api.Client.Models.ProfileApi;
using Anihithe.Wow.Api.Client.Models.Reworked;
using Discord;

namespace Anihithe.Discord.Bot.WowScout.Services;

public class EmbedService
{
    public Embed SimpleEmbed(DtoRoot character)
    {
        var embed = new EmbedBuilder()
            .WithColor(Color.Teal)
            .WithDescription("New Legend is born !")
            .AddField("Player", character.Character.Name, true)
            .AddField("Boss",
                character.Expansions![0].Instances[0].Modes[0].Progress.Encounters[0].Encounter.Name, true)
            .AddField("Status",
                $"{(character.Expansions![0].Instances[0].Modes[0].Progress.Encounters[0].CompletedCount >= 1 ? "Killed" : "Alive")}",
                true);

        return embed.Build();
    }

    public Embed SimpleProgressEmbed(AutoCheck character)
    {
        var bossList = new StringBuilder();
        foreach (var encounter in character.encounters)
        {
            bossList.AppendLine(
                $"[{encounter.ModeName}] {encounter.RaidName} - {encounter.BossName} {encounter.LastKillTimeStamp.ToLocalTime()}");
        }

        var embed = new EmbedBuilder()
            .WithColor(Color.Teal)
            .WithDescription("New Kill !")
            .AddField("Player", character.PlayerName, true)
            .AddField("Encounters", bossList, true);

        return embed.Build();
    }


    public Embed NoSoSimpleEmbed(DtoRoot character)
    {
        var rand = new Random();
        var randExp = rand.Next(0, character.Expansions!.Count - 1);
        var randInst = rand.Next(0, character.Expansions[randExp].Instances.Count - 1);
        var randMode = rand.Next(0, character.Expansions[randExp].Instances[randInst].Modes.Count - 1);

        var bossList = new StringBuilder();
        var bossStatus = new StringBuilder();
        var lastkill = new StringBuilder();

        foreach (var encounter in character.Expansions![randExp].Instances[randInst].Modes[randMode].Progress
                     .Encounters)
        {
            bossList.AppendLine(encounter.Encounter.Name);
            bossStatus.AppendLine(
                $"{(encounter.CompletedCount == 0 ? "Alive" : "Killed")} ({encounter.CompletedCount} times)");
            lastkill.AppendLine(
                $"{DateTimeOffset.FromUnixTimeMilliseconds((long) encounter.LastKillTimestamp).ToLocalTime()}");
        }

        var embed = new EmbedBuilder()
            .WithColor(Color.Teal)
            .WithDescription(
                $"Progress of {character.Character.Name} in {character.Expansions![randExp].Instances[randInst].Modes[randMode].Difficulty.Name} {character.Expansions![randExp].Instances[randInst].Instance.Name}")
            .AddField("Boss",
                bossList, true)
            .AddField("Status", bossStatus, true)
            .AddField("Last kill", lastkill, true);


        return embed.Build();
    }

    public Embed NotSoSimpleProgressEmbed(AutoCheck character, EmbedBuilder embed)
    {
        var bossList = new StringBuilder();
        foreach (var encounter in character.encounters)
        {
            bossList.AppendLine(
                $"[{encounter.ModeName}] {encounter.RaidName} - {encounter.BossName} {encounter.LastKillTimeStamp.ToLocalTime()}");
        }

        embed.AddField("Player", character.PlayerName)
            .AddField("Encounters", bossList, true);

        return embed.Build();
    }
}