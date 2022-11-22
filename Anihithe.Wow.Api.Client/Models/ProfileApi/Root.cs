using System.Text.Json.Serialization;

namespace Anihithe.Wow.Api.Client;

public record Root(
    [property: JsonPropertyName("character")]
    Character Character,
    [property: JsonPropertyName("expansions")]
    IReadOnlyList<Expansion> Expansions
);