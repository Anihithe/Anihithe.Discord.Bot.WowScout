using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace Anihithe.Wow.Api.Client.Models;

public record RaidApi(
    [property: JsonProperty("character")]Character Character,
    [property: JsonProperty("expansions")]IReadOnlyList<Expansions> Expansions);