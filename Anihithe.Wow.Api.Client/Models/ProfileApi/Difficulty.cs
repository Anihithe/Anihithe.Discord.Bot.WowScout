using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace Anihithe.Wow.Api.Client;

public record Difficulty(
    [property: JsonProperty("type")] string Type,
    [property: JsonProperty("name")] string Name
);