using System.Text.Json.Serialization;

namespace Anihithe.Wow.Api.Client;

public record Instance(
    [property: JsonPropertyName("id")] int Id,
    [property: JsonPropertyName("name")] string Name,
    [property: JsonPropertyName("modes")] IReadOnlyList<Mode> Modes
);