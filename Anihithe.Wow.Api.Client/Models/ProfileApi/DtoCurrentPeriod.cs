using Newtonsoft.Json;

namespace Anihithe.Wow.Api.Client.Models.ProfileApi;

public record DtoCurrentPeriod(
    [JsonProperty("period")] DtoPeriod Period
);
