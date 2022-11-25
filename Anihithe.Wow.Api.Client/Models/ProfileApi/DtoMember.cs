using Newtonsoft.Json;

namespace Anihithe.Wow.Api.Client.Models.ProfileApi;

public record DtoMember(
    [JsonProperty("character")]
    DtoCharacter Character,
    [JsonProperty("specialization")]
    DtoSpecialization Specialization,
    [JsonProperty("race")] DtoRace Race,
    [JsonProperty("equipped_item_level")]
    int EquippedItemLevel
);