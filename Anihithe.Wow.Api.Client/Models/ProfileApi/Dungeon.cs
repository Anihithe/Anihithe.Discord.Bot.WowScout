﻿using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace Anihithe.Wow.Api.Client;

public record Dungeon(
    [property: JsonProperty("name")] string Name,
    [property: JsonProperty("id")] int Id
);