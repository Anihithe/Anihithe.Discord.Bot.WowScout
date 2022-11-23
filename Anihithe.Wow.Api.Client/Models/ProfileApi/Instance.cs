using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace Anihithe.Wow.Api.Client;

public record Instance(
    [property: JsonProperty("id")] int Id,
    [property: JsonProperty("name")] string Name
    
);

public record Instances(
    [property: JsonProperty("instance")] Instance Instance,
    [property: JsonProperty("modes")] IReadOnlyList<Mode> Modes);