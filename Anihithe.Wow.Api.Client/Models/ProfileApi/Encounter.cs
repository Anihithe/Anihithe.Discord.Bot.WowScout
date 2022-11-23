using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace Anihithe.Wow.Api.Client;

public record Encounter(
    [property: JsonProperty("id")] int Id,
    [property: JsonProperty("name")] string Name,
    [property: JsonProperty("completed_count")]
    int CompletedCount,
    [property: JsonProperty("last_kill_timestamp")]
    object LastKillTimestamp
);