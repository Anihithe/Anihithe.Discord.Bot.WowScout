using System.Text;
using Anihithe.Wow.Api.Client.Models;
using Newtonsoft.Json;

namespace Anihithe.Discord.Bot.WowScout.Services;

public static class BlizzardOAuth2
{
    public static Token? Token;

    public static async Task GetToken(string clientId, string clientSecret, string oAuthUrl)
    {
        var client = new HttpClient();
        var request = new HttpRequestMessage();
        var base64Authorization = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{clientId}:{clientSecret}"));
        request.RequestUri = new Uri(oAuthUrl);
        request.Method = HttpMethod.Post;

        request.Headers.Add("Accept", "*/*");
        request.Headers.Add("Authorization", $"Basic {base64Authorization}");

        var content = new MultipartFormDataContent();
        content.Add(new StringContent("client_credentials"), "grant_type");
        request.Content = content;

        var response = await client.SendAsync(request);
        var result = await response.Content.ReadAsStringAsync();
        Token = JsonConvert.DeserializeObject<Token>(result);
    }
}