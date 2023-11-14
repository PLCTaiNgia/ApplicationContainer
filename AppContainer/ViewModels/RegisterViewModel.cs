using AppContainer.Common;
using AppContainer.Dto;
using AppContainer.Services.AuthService;
using AppContainer.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace AppContainer.ViewModels
{
    public partial class RegisterViewModel : BaseViewModel
    {
        private readonly IAuthService authService;
        public RegisterViewModel(IAuthService authService)
        {
            this.authService = authService;
        }

        [ObservableProperty]
        private string fullName;

        [ObservableProperty]
        private string username;

        [ObservableProperty]
        private string password;

        [ObservableProperty]
        private string confirmPassword;

        [RelayCommand]
        async Task RedirectToLoginPage()
        {
            await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
        }

        [RelayCommand]
        async Task Register()
        {
            var registerDto = new RegisterDto
            {
                FullName = FullName,
                Username = Username,
                Password = Password,
                ConfirmPassword = ConfirmPassword
            };

            var registerSuccess = await authService.RegisterAsync(registerDto);
            if (registerSuccess)
            {
                await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
            }
        }
    }
}
