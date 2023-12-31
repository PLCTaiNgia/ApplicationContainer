﻿using AppContainer.Common;
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

        public async Task<ResponseApi<AuthResponse>> LoginAsync(LoginDto loginDto)
        {
            var jsonLoginPayload = JsonConvert.SerializeObject(loginDto);
            var data = new StringContent(jsonLoginPayload, Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync("login", data);
            string resultString = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<ResponseApi<AuthResponse>>(resultString);
            //da check dk
            if (result.Success == true && result.Data != null)
            {
                await SecureStorage.Default.SetAsync(constants.TOKEN, result.Data.Token.AccessToken);
                await SecureStorage.Default.SetAsync(constants.CURRENT_USER, JsonConvert.SerializeObject(result.Data.User));

            }

            return result;
        }

        public async Task<bool> RegisterAsync(RegisterDto registerDto)
        {
            var jsonRegisterPayload = JsonConvert.SerializeObject(registerDto);
            var data = new StringContent(jsonRegisterPayload, Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync("register", data);
            string resultString = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<ResponseApi<Boolean>>(resultString);

            return result.Success;
        }
    }
}
