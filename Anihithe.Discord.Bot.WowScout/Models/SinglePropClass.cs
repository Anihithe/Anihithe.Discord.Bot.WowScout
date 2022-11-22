using Newtonsoft.Json;

namespace Anihithe.Discord.Bot.WowScout.Models;

public class SinglePropClass
{
    [JsonProperty("name")] public string Name;
}