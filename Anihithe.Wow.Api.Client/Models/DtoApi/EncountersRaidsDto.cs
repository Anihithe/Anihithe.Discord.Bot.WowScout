using Anihithe.Wow.Api.Client.Models.ProfileApi;
using Newtonsoft.Json;

namespace Anihithe.Wow.Api.Client.Models.DtoApi;

public record EncountersRaidsDto(
    [JsonProperty("character")]DtoCharacter DtoCharacter,
    [JsonProperty("expansions")]IReadOnlyList<DtoExpansions> Expansions);