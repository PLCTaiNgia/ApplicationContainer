using AppContainer.Common;
using AppContainer.Dto;
using AppContainer.Models;
using Newtonsoft.Json;
using System.Text;

namespace AppContainer.Services.AuthService
{
    public class AuthService : IAuthService
    {
        private readonly HttpClient httpClient;
        public AuthService()
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri($"{constants.URL}/auth/");
        }
        public async Task<bool> Login(LoginDto loginDto)
        {
            var jsonLoginPayload = JsonConvert.SerializeObject(loginDto);
            var data = new StringContent(jsonLoginPayload, Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync("login", data);
            string resultString = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<ResponseApi<AuthResponse>>(resultString);

            await SecureStorage.Default.SetAsync(constants.TOKEN, result.Data.Token.AccessToken);
            await SecureStorage.Default.SetAsync(constants.CURRENT_USER, JsonConvert.SerializeObject(result.Data.User));

            return result.Success;
        }
    }
}
