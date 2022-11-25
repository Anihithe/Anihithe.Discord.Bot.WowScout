using Newtonsoft.Json;

namespace Anihithe.Wow.Api.Client.Models.ProfileApi;

public record DtoSeason(
    [JsonProperty("id")] int Id
);