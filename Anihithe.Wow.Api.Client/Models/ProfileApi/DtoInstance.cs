using Newtonsoft.Json;

namespace Anihithe.Wow.Api.Client.Models.ProfileApi;

public record DtoInstance(
    [JsonProperty("id")] int Id,
    [JsonProperty("name")] string Name
    
);

public record DtoInstances(
    [JsonProperty("instance")] DtoInstance Instance,
    [JsonProperty("modes")] IReadOnlyList<DtoMode> Modes);