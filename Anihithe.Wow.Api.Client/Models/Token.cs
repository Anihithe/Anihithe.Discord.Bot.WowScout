using Newtonsoft.Json;

namespace Anihithe.Wow.Api.Client.Models;

public record Token(
    [JsonProperty("access_token")]
    string accessToken,
    [JsonProperty("expires_in")]
    int expiresIn,
    [JsonProperty("scope")] string scope,
    [JsonProperty("token_type")]
    string tokenType
);