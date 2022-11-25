using Newtonsoft.Json;

namespace Anihithe.Wow.Api.Client.Models.ProfileApi;

public record DtoBestRun(
    [JsonProperty("completed_timestamp")]
    object CompletedTimestamp,
    [JsonProperty("duration")]
    int Duration,
    [JsonProperty("keystone_level")]
    int KeystoneLevel,
    [JsonProperty("keystone_affixes")]
    IReadOnlyList<DtoKeystoneAffix> KeystoneAffixes,
    [JsonProperty("members")]
    IReadOnlyList<DtoMember> Members,
    [JsonProperty("dungeon")]
    DtoDungeon Dungeon,
    [JsonProperty("is_completed_within_time")]
    bool IsCompletedWithinTime,
    [JsonProperty("mythic_rating")]
    DtoMythicRating MythicRating
);