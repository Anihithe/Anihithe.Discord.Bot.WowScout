using Newtonsoft.Json;

namespace Anihithe.Wow.Api.Client.Models.ProfileApi;

public record DtoColor(
    [JsonProperty("r")] int R,
    [JsonProperty("g")] int G,
    [JsonProperty("b")] int B,
    [JsonProperty("a")] int A
);