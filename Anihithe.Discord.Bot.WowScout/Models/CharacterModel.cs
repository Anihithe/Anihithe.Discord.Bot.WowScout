using Newtonsoft.Json;

namespace Anihithe.Discord.Bot.WowScout.Models;

public class CharacterModel
{
    [JsonProperty("character_class")] public CharacterClass Classe;
    [JsonProperty("guild")] public Guild Guild;
    [JsonProperty("name")] public string Name;
    [JsonProperty("race")] public Race Race;
    [JsonProperty("realm")] public Realm Realm;

    public override string ToString()
    {
        return $@"Nom: {Name}
Race: {Race.Name}
Classe: {Classe.Name}
Serveur: {Realm.Name}
Guilde: {Guild.Name}";
    }
}

public class SinglePropClass
{
    [JsonProperty("name")] public string Name;
}

public class Guild : SinglePropClass
{
}

public class Realm : SinglePropClass
{
}

public class Race : SinglePropClass
{
}

public class CharacterClass : SinglePropClass
{
}