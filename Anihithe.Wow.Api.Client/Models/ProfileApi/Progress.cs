using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace Anihithe.Wow.Api.Client;

public record Progress(
    [property: JsonProperty("completed_count")]
    int CompletedCount,
    [property: JsonProperty("total_count")]
    int TotalCount,
    [property: JsonProperty("encounters")]
    IReadOnlyList<Encounter> Encounters
);