using Newtonsoft.Json;

namespace Anihithe.Wow.Api.Client.Models.ProfileApi;

public record DtoDifficulty(
    [JsonProperty("type")] string Type,
    [JsonProperty("name")] string Name
);