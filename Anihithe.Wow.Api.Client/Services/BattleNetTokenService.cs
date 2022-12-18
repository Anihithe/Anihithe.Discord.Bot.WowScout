using System.Net.Http.Headers;
using System.Text;
using Anihithe.Wow.Api.Client.Models;
using Anihithe.Wow.Api.Client.Models.Auth;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace Anihithe.Wow.Api.Client.Services;

public class BattleNetTokenService
{
    private readonly HttpClient _httpClient;
    private BattleNetToken _token = new();
    private readonly BattleNetSettings _battleNetSettings;

    public BattleNetTokenService(HttpClient httpClient, IOptions<BattleNetSettings> battleNetSettings)
    {
        _httpClient = httpClient;
        _battleNetSettings = battleNetSettings.Value;
    }
    
    public async Task<string> GetToken()
    {
        if (!_token.IsValidAndNotExpiring)
        {
            _token = await GetNewAccessToken();
        }
        return _token.AccessToken;
    }

    private async Task<BattleNetToken> GetNewAccessToken()
    {
        var content = new MultipartFormDataContent();
        content.Add(new StringContent("client_credentials"), "grant_type");
        var request = new HttpRequestMessage(HttpMethod.Post, _battleNetSettings.TokenUrl)
        {
            Content = content
        };
        var base64Authorization = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{_battleNetSettings.ClientId}:{_battleNetSettings.ClientSecret}"));
        request.Headers.Add("Accept", "*/*");
        request.Headers.Add("Authorization", $"Basic {base64Authorization}");

        var response = await _httpClient.SendAsync(request);
        if(response.IsSuccessStatusCode)
        {
            try
            {
                var json = await response.Content.ReadAsStringAsync();
                _token = JsonConvert.DeserializeObject<BattleNetToken>(json);
                _token.ExpiresAt = DateTime.UtcNow.AddSeconds(_token.ExpiresIn);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }
        else
        {
            throw new ApplicationException("Unable to retrieve access token from BattleNet");
        }
        return _token;
    }
}

