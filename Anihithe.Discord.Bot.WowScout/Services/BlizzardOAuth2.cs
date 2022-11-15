using System.Text;
using Anihithe.Discord.Bot.WowScout.Models;
using Newtonsoft.Json;

namespace Anihithe.Discord.Bot.WowScout.Services;

public static class BlizzardOAuth2
{
    public static WowToken wowToken;

    public static async Task GetToken(string clientId, string clientSecret)
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
        wowToken = JsonConvert.DeserializeObject<WowToken>(result);
    }
}