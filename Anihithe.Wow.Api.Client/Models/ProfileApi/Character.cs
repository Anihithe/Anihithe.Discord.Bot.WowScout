using System.Text.Json.Serialization;

namespace Anihithe.Wow.Api.Client;

// Root myDeserializedClass = JsonSerializer.Deserialize<Root>(myJsonResponse);
public record Character(
    [property: JsonPropertyName("name")] string Name,
    [property: JsonPropertyName("id")] int Id,
    [property: JsonPropertyName("realm")] Realm Realm
);