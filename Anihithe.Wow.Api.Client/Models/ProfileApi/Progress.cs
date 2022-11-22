using System.Text.Json.Serialization;

namespace Anihithe.Wow.Api.Client;

public record Progress(
    [property: JsonPropertyName("completed_count")]
    int CompletedCount,
    [property: JsonPropertyName("total_count")]
    int TotalCount,
    [property: JsonPropertyName("encounters")]
    IReadOnlyList<Encounter> Encounters
);