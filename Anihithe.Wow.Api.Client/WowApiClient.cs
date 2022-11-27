using Anihithe.Wow.Api.Client.Services;

namespace Anihithe.Wow.Api.Client;

public class WowApiClient
{
    private string clientId { get; set; }
    private string clientSecret { get; set; }

    public async Task Config(string id, string secret)
    {
        clientId = id;
        clientSecret = secret;
         await GetToken();
    }

    public async Task GetToken()
    {
        await BlizzardOAuth2.GetToken(clientId, clientSecret);
    }
}