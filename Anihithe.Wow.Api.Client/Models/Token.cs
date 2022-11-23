using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace Anihithe.Wow.Api.Client.Models;

public record Token(
    [property: JsonProperty("access_token")]
    string accessToken,
    [property: JsonProperty("expires_in")]
    int expiresIn,
    [property: JsonProperty("scope")] string scope,
    [property: JsonProperty("token_type")]
    string tokenType
);