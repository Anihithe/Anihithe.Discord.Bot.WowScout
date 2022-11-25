using Newtonsoft.Json;

namespace Anihithe.Wow.Api.Client.Models.ProfileApi;

public record DtoStatus(
    [JsonProperty("type")] string Type,
    [JsonProperty("name")] string Name
);