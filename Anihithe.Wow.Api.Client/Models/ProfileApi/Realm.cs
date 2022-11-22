using System.Text.Json.Serialization;

namespace Anihithe.Wow.Api.Client;

public record Realm(
    [property: JsonPropertyName("name")] string Name,
    [property: JsonPropertyName("id")] int Id,
    [property: JsonPropertyName("slug")] string Slug
);