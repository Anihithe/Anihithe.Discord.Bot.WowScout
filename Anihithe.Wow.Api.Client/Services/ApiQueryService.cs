using System.Net;
using Anihithe.Wow.Api.Client.Models.Auth;
using Anihithe.Wow.Api.Client.Models.ProfileApi;
using Newtonsoft.Json;

namespace Anihithe.Wow.Api.Client.Services;

public class ApiQueryService
{
    private readonly BattleNetTokenService _battleNetTokenService;

    public ApiQueryService(BattleNetTokenService battleNetTokenService)
    {
        _battleNetTokenService = battleNetTokenService;
    }
    
    // Note: RaidProgress ne retourne que la liste des boss down par le joueur. Impossible d'afficher la liste des boss en vie.
    public async Task<DtoRoot> GetRaidProgress(string realm, string characterName)
    {
        var client = new HttpClient();
        var uri = new Uri(
            $"https://eu.api.blizzard.com/profile/wow/character/{realm}/{characterName}/encounters/raids?namespace=profile-eu&locale=fr_FR&access_token={await _battleNetTokenService.GetToken()}");

        var response = await client.GetAsync(uri);
        var result = await response.Content.ReadAsStringAsync();
        var character = JsonConvert.DeserializeObject<DtoRoot>(result);

        return character;
    }

    public async Task<DtoRoot> GetCharacterDetail(string realm, string characterName)
    {
        var client = new HttpClient();
        var uri = new Uri(
            $"https://eu.api.blizzard.com/profile/wow/character/{realm}/{characterName}character-media?namespace=profile-eu&locale=fr_FR&access_token={_battleNetTokenService.GetToken()}");
        var response = await client.GetAsync(uri);
        var result = await response.Content.ReadAsStringAsync();
        var character = JsonConvert.DeserializeObject<DtoRoot>(result);

        return character;
    }
}