using System.Text;
using Anihithe.Wow.Api.Client.Models;
using Newtonsoft.Json;

namespace Anihithe.Wow.Api.Client.Services;

public static class BlizzardOAuth2
{
    private static string _clientId;
    private static string _clientSecret;
    public static Token? Token { get; private set; }

    private const string O_AUTH_URL = "https://oauth.battle.net/token";

    public static async Task GetToken(string clientId, string clientSecret)
    {
        _clientId = clientId;
        _clientSecret = clientSecret;
        var client = new HttpClient();
        var request = new HttpRequestMessage();
        var base64Authorization = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{clientId}:{clientSecret}"));
        request.RequestUri = new Uri(O_AUTH_URL);
        request.Method = HttpMethod.Post;

        request.Headers.Add("Accept", "*/*");
        request.Headers.Add("Authorization", $"Basic {base64Authorization}");

        var content = new MultipartFormDataContent();
        content.Add(new StringContent("client_credentials"), "grant_type");
        request.Content = content;

        var response = await client.SendAsync(request);
        var result = await response.Content.ReadAsStringAsync();
        Token = JsonConvert.DeserializeObject<Token>(result)!;
    }

    public static async Task RenewToken()
    {
        await GetToken(_clientId, _clientSecret);
    }
}