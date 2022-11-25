using Newtonsoft.Json;

namespace Anihithe.Wow.Api.Client.Models.ProfileApi;

public record DtoRealm(
    [JsonProperty("name")] string Name,
    [JsonProperty("id")] int Id,
    [JsonProperty("slug")] string Slug
);