using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace Anihithe.Wow.Api.Client;

public record MythicRating(
    [property: JsonProperty("color")] Color Color,
    [property: JsonProperty("rating")] double Rating
);