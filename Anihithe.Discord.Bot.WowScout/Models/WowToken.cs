using Newtonsoft.Json;

namespace Anihithe.Discord.Bot.WowScout.Models;

public class WowToken
{
    [JsonProperty("access_token")] public string accessToken;
    [JsonProperty("token_type")] public string tokenType;
    [JsonProperty("expires_in")] public int expiresIn;
    [JsonProperty("scope")] public string scope;
}