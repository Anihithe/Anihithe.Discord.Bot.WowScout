using System.Text.Json.Serialization;

namespace Anihithe.Wow.Api.Client;

public record Encounter(
    [property: JsonPropertyName("id")] int Id,
    [property: JsonPropertyName("name")] string Name,
    [property: JsonPropertyName("completed_count")]
    int CompletedCount,
    [property: JsonPropertyName("last_kill_timestamp")]
    object LastKillTimestamp
);