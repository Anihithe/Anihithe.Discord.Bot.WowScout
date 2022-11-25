using Newtonsoft.Json;

namespace Anihithe.Wow.Api.Client.Models.ProfileApi;

public record DtoMode(
    [JsonProperty("difficulty")]
    DtoDifficulty Difficulty,
    [JsonProperty("status")] DtoStatus Status,
    [JsonProperty("progress")]
    DtoProgress Progress
);