using Newtonsoft.Json;

namespace Anihithe.Wow.Api.Client.Models.ProfileApi;

public record DtoDungeon(
    [JsonProperty("name")] string Name,
    [JsonProperty("id")] int Id
);