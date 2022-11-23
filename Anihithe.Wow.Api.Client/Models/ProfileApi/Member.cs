using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace Anihithe.Wow.Api.Client;

public record Member(
    [property: JsonProperty("character")]
    Character Character,
    [property: JsonProperty("specialization")]
    Specialization Specialization,
    [property: JsonProperty("race")] Race Race,
    [property: JsonProperty("equipped_item_level")]
    int EquippedItemLevel
);