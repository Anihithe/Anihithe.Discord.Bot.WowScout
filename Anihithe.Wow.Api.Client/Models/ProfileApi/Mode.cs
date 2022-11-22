using System.Text.Json.Serialization;

namespace Anihithe.Wow.Api.Client;

public record Mode(
    [property: JsonPropertyName("difficulty")]
    Difficulty Difficulty,
    [property: JsonPropertyName("status")] Status Status,
    [property: JsonPropertyName("progress")]
    Progress Progress
);