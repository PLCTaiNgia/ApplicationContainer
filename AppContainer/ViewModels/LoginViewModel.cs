using AppContainer.Common;
using AppContainer.Dto;
using AppContainer.Services.AuthService;
using AppContainer.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace AppContainer.ViewModels
{
    public partial class LoginViewModel : BaseViewModel
    {
        private readonly IAuthService authService;
        public LoginViewModel(IAuthService authService)
        {
            this.authService = authService;
        }

        [ObservableProperty]
        private string userName;

        [ObservableProperty]
        private string password;

        [RelayCommand]
        async Task Login()
        {
            var loginPayload = new LoginDto { UserName = UserName, Password = Password };

            var result = await authService.Login(loginPayload);

            if (result)
            {
                await Shell.Current.GoToAsync($"{nameof(HomePage)}");
            }
            else
            {

            }
        }
    }
}
