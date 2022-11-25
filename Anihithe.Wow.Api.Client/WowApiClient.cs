using Anihithe.Wow.Api.Client.Services;

namespace Anihithe.Wow.Api.Client;

public class WowApiClient
{
    private string clientId { get; set; }
    private string clientSecret { get; set; }

    public void Config(string id, string secret)
    {
        clientId = id;
        clientSecret = secret;
        GetToken();
    }

    public async void GetToken()
    {
        await BlizzardOAuth2.GetToken(clientId, clientSecret);
    }
}