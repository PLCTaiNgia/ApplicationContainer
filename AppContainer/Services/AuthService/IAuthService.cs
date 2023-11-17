using AppContainer.Common;
using AppContainer.Dto;
using AppContainer.Models;

namespace AppContainer.Services.AuthService
{
    public interface IAuthService
    {
        Task<ResponseApi<AuthResponse>> LoginAsync(LoginDto loginDto);
        Task<bool> RegisterAsync(RegisterDto registerDto);
    }
}
