using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace Anihithe.Wow.Api.Client;

public record CurrentPeriod(
    [property: JsonProperty("period")] Period Period
);
