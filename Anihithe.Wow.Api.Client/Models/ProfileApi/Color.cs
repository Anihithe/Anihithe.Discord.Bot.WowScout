using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace Anihithe.Wow.Api.Client;

public record Color(
    [property: JsonProperty("r")] int R,
    [property: JsonProperty("g")] int G,
    [property: JsonProperty("b")] int B,
    [property: JsonProperty("a")] int A
);