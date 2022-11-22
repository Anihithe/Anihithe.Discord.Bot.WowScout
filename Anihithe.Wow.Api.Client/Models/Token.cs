using Newtonsoft.Json;

namespace Anihithe.Wow.Api.Client.Models;

public class Token
{
    [JsonProperty("access_token")] public string accessToken;
    [JsonProperty("expires_in")] public int expiresIn;
    [JsonProperty("scope")] public string scope;
    [JsonProperty("token_type")] public string tokenType;
}