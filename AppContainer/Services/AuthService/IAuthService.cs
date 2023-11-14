using AppContainer.Dto;

namespace AppContainer.Services.AuthService
{
    public interface IAuthService
    {
        Task<bool> Login(LoginDto loginDto);
    }
}
