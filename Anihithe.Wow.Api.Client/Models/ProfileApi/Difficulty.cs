using System.Text.Json.Serialization;

namespace Anihithe.Wow.Api.Client;

public record Difficulty(
    [property: JsonPropertyName("type")] string Type,
    [property: JsonPropertyName("name")] string Name
);