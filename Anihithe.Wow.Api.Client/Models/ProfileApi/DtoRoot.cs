using Newtonsoft.Json;

namespace Anihithe.Wow.Api.Client.Models.ProfileApi;

public record DtoRoot(
    [JsonProperty("character")]
    DtoCharacter Character,
    [JsonProperty("expansions")]
    IReadOnlyList<DtoExpansions>? Expansions
);