using Newtonsoft.Json;

namespace Anihithe.Wow.Api.Client.Models.Auth;

public class BattleNetToken
{
    [JsonProperty("access_token")] public string AccessToken { get; set; } = string.Empty;
    [JsonProperty("expires_in")] public int ExpiresIn { get; set; }
    [JsonProperty("scope")] public string Scope { get; set; } = string.Empty;
    [JsonProperty("token_type")] public string TokenType { get; set; } = string.Empty;
    [JsonProperty("sub")] public string Sub { get; set; }
    public DateTime ExpiresAt { get; set; }
    public bool IsValidAndNotExpiring =>
        !string.IsNullOrEmpty(AccessToken) &&
        ExpiresAt > DateTime.UtcNow.AddSeconds(30);
}