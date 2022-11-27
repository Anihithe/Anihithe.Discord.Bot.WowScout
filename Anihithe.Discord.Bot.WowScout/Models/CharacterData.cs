using System.Runtime.InteropServices.ComTypes;
using Anihithe.Wow.Api.Client.Models.ProfileApi;
using Anihithe.Wow.Api.Client.Models.Reworked;

namespace Anihithe.Discord.Bot.WowScout.Models;

public class CharacterData
{
    public readonly string Realm;
    public readonly string Name;
    public DateTimeOffset Lastkilldatetime;

    internal CharacterData(string realm, string name)
    {
        Realm = realm.ToLower();
        Name = name.ToLower();
    }
    internal CharacterData(string realm, string name, DateTimeOffset lastkilldatetime)
    {
        Realm = realm.ToLower();
        Name = name.ToLower();
        Lastkilldatetime = lastkilldatetime;
    }
}

public static class Toto
{
    public static List<CharacterData> TryAdd(this List<CharacterData> datas, DtoRoot root)
    {
        var val = new AutoCheck(root);
        if (root.Character.Name != string.Empty)
        {
            datas.Add(new CharacterData(root.Character.Realm.Slug, root.Character.Name.ToLower(), val.encounters.Max(x=> x.LastKillTimeStamp)));
        }
        return datas;
    }
}