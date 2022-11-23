using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace Anihithe.Wow.Api.Client;

public record Expansion(
    [property: JsonProperty("id")] int Id,
    [property: JsonProperty("name")] string Name
);

public record Expansions(
    [property: JsonProperty("expansion")] Expansion Expansion,
    [property: JsonProperty("instances")] IReadOnlyList<Instances> Instances);