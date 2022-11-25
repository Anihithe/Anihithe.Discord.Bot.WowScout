using Newtonsoft.Json;

namespace Anihithe.Wow.Api.Client.Models.ProfileApi;

public record DtoExpansion(
    [JsonProperty("id")] int Id,
    [JsonProperty("name")] string Name
);

public record DtoExpansions(
    [JsonProperty("expansion")] DtoExpansion Expansion,
    [JsonProperty("instances")] IReadOnlyList<DtoInstances> Instances);