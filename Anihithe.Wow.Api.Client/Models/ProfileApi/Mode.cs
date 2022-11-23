using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace Anihithe.Wow.Api.Client;

public record Mode(
    [property: JsonProperty("difficulty")]
    Difficulty Difficulty,
    [property: JsonProperty("status")] Status Status,
    [property: JsonProperty("progress")]
    Progress Progress
);