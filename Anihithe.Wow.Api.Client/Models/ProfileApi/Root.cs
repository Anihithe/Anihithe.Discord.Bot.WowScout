using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace Anihithe.Wow.Api.Client;

public record Root(
    [property: JsonProperty("character")]
    Character Character,
    [property: JsonProperty("expansions")]
    IReadOnlyList<Expansion> Expansions
);