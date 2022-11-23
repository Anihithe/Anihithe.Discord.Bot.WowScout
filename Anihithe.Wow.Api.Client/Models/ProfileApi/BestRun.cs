using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace Anihithe.Wow.Api.Client;

public record BestRun(
    [property: JsonProperty("completed_timestamp")]
    object CompletedTimestamp,
    [property: JsonProperty("duration")]
    int Duration,
    [property: JsonProperty("keystone_level")]
    int KeystoneLevel,
    [property: JsonProperty("keystone_affixes")]
    IReadOnlyList<KeystoneAffix> KeystoneAffixes,
    [property: JsonProperty("members")]
    IReadOnlyList<Member> Members,
    [property: JsonProperty("dungeon")]
    Dungeon Dungeon,
    [property: JsonProperty("is_completed_within_time")]
    bool IsCompletedWithinTime,
    [property: JsonProperty("mythic_rating")]
    MythicRating MythicRating
);