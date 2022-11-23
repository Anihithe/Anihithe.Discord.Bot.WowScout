using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace Anihithe.Wow.Api.Client;

public record Period(
    [property: JsonProperty("id")] int Id
);