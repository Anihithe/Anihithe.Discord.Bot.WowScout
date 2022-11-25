using Anihithe.Wow.Api.Client.Models.ProfileApi;
using Newtonsoft.Json;

namespace Anihithe.Wow.Api.Client.Services;

public class ApiQueryService
{
    public async Task<DtoRoot> GetRaidProgress(string realm, string characterName)
    {
        var client = new HttpClient();
        var uri = new Uri(
            $"https://eu.api.blizzard.com/profile/wow/character/{realm}/{characterName}/encounters/raids?namespace=profile-eu&locale=fr_FR&access_token={BlizzardOAuth2.Token.accessToken}");
        var response = await client.GetAsync(uri);
        var result = await response.Content.ReadAsStringAsync();
        var character = JsonConvert.DeserializeObject<DtoRoot>(result);

        return character;
    }
}