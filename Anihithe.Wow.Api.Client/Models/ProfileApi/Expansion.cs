using System.Text.Json.Serialization;

namespace Anihithe.Wow.Api.Client;

public record Expansion(
    [property: JsonPropertyName("id")] int Id,
    [property: JsonPropertyName("name")] string Name,
    [property: JsonPropertyName("instances")]
    IReadOnlyList<Instance> Instances
);