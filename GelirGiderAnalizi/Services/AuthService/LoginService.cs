using GelirGiderAnalizi.Models.GelirGiderAnalizi.Models;
using GelirGiderAnalizi.Models;
using GelirGiderAnalizi.Services.AuthService;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

public class LoginService : ILoginService
{
    private readonly HttpClient _httpClient;
    private string? _token;

    public LoginService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<LoginResponse> LoginAsync(LoginModel loginModel)
    {
        // İsteği Hazırlayıp gönderme Serilizasyon
        var loginRequestContent = new StringContent(JsonConvert.SerializeObject(loginModel), Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync("https://apiv3.bilsoft.com/api/Auth/GirisYap", loginRequestContent);

        if (response.IsSuccessStatusCode)
        {
            // Dönen Modeli Deselize et
            var content = await response.Content.ReadAsStringAsync();
            var loginResponse = JsonConvert.DeserializeObject<LoginResponse>(content);

            return loginResponse!;
        }

        return null!;
    }
}
