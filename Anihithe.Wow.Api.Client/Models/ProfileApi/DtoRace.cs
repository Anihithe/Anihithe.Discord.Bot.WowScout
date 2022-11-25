using Newtonsoft.Json;

namespace Anihithe.Wow.Api.Client.Models.ProfileApi;

public record DtoRace(
    [JsonProperty("name")] string Name,
    [JsonProperty("id")] int Id
);