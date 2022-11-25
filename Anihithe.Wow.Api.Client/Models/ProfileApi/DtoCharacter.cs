using Newtonsoft.Json;

namespace Anihithe.Wow.Api.Client.Models.ProfileApi;

public record DtoCharacter(
    [JsonProperty("name")] string Name,
    [JsonProperty("id")] int Id,
    [JsonProperty("realm")] DtoRealm Realm
);