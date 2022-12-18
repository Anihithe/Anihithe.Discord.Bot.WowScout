namespace Anihithe.Wow.Api.Client.Models.Auth;

public class BattleNetSettings
{
    public const string BATTLE_NET = "BattleNet";
    public string ClientId { get; set; }
    public string ClientSecret { get; set; }
    public string TokenUrl { get; set; }
}