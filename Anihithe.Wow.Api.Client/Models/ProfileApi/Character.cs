using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace Anihithe.Wow.Api.Client;

// Root myDeserializedClass = JsonSerializer.Deserialize<Root>(myJsonResponse);
public record Character(
    [property: JsonProperty("name")] string Name,
    [property: JsonProperty("id")] int Id,
    [property: JsonProperty("realm")] Realm Realm
);