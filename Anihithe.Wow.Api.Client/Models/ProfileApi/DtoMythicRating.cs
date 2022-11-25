using Newtonsoft.Json;

namespace Anihithe.Wow.Api.Client.Models.ProfileApi;

public record DtoMythicRating(
    [JsonProperty("color")] DtoColor Color,
    [JsonProperty("rating")] double Rating
);