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
        private bool userNameError;
        [ObservableProperty]
        private string userNameErrorMessage;


        [ObservableProperty]
        private string password;
        [ObservableProperty]
        private bool passwordError;
        [ObservableProperty]
        private string passwordErrorMessage;

        [RelayCommand]
        async Task Login()
        {
            if (!string.IsNullOrWhiteSpace(UserName) && !string.IsNullOrWhiteSpace(Password))
            {
                var loginPayload = new LoginDto { UserName = UserName, Password = Password };

                var result = await authService.LoginAsync(loginPayload);

                if (result)
                {
                    await Shell.Current.GoToAsync($"//{nameof(HomePage)}");
                }
                else
                {
                    //Show toast thông báo lỗi từ api trả về
                }
            }
            else
            {
                UserNameError = true;
                UserNameErrorMessage = "Vui lòng nhập trường này";

                PasswordError = true;
                PasswordErrorMessage = "Vui lòng nhập trường này";
            }
        }

        [RelayCommand]
        async Task RedirectToRegisterPage()
        {
            await Shell.Current.GoToAsync($"//{nameof(RegisterPage)}");
        }

        [RelayCommand]
        void ValidateUsername()
        {
            if (string.IsNullOrWhiteSpace(UserName))
            {
                UserNameError = true;
                UserNameErrorMessage = "Vui lòng nhập trường này";
            }
            else
            {
                UserNameError = false;
                UserNameErrorMessage = "";
            }
        }

        [RelayCommand]
        void ValidatePassword()
        {
            if (string.IsNullOrWhiteSpace(Password))
            {
                PasswordError = true;
                PasswordErrorMessage = "Vui lòng nhập trường này";
            }
            else
            {
                PasswordError = false;
                PasswordErrorMessage = "";
            }
        }
    }
}
