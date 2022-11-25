using Newtonsoft.Json;

namespace Anihithe.Wow.Api.Client.Models.ProfileApi;

public record DtoProgress(
    [JsonProperty("completed_count")]
    int CompletedCount,
    [JsonProperty("total_count")]
    int TotalCount,
    [JsonProperty("encounters")]
    IReadOnlyList<DtoEncounters> Encounters
);