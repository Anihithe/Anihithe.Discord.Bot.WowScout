using System.Text;
using System.Transactions;
using Anihithe.Discord.Bot.WowScout.Models;
using Newtonsoft.Json;

namespace Anihithe.Discord.Bot.WowScout.Services;

public static class BlizzardOAuth2
{
    public static async Task<WowToken> GetToken(string clientId, string clientSecret)
    {
        var client = new HttpClient();
        var request = new HttpRequestMessage();
        var base64Authorization = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{clientId}:{clientSecret}"));
        request.RequestUri = new Uri("https://oauth.battle.net/token");
        request.Method = HttpMethod.Post;

        request.Headers.Add("Accept", "*/*");
        request.Headers.Add("Authorization", $"Basic {base64Authorization}");

        var content = new MultipartFormDataContent();
        content.Add(new StringContent("client_credentials"), "grant_type");
        request.Content = content;

        var response = await client.SendAsync(request);
        var result = await response.Content.ReadAsStringAsync();
        var a = JsonConvert.DeserializeObject<WowToken>(result);
        return a ?? new WowToken(); // TODO: Pas propre, TryCatch
    }
}