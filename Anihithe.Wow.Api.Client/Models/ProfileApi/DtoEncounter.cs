using Newtonsoft.Json;

namespace Anihithe.Wow.Api.Client.Models.ProfileApi;

public record DtoEncounter(
    [JsonProperty("id")] int Id,
    [JsonProperty("name")] string Name
);

public record DtoEncounters([JsonProperty("completed_count")]
    int CompletedCount,
    [JsonProperty("last_kill_timestamp")]
    object LastKillTimestamp,
    [JsonProperty("encounter")] DtoEncounter Encounter);