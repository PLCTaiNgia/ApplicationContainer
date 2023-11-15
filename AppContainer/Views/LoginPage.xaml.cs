using AppContainer.ViewModels;

namespace AppContainer.Views;

public partial class LoginPage : ContentPage
{
    public LoginPage(LoginViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }

    protected override async void OnAppearing()
    {
        SecureStorage.Default.RemoveAll();

        base.OnAppearing();
        if (!string.IsNullOrEmpty(await SecureStorage.Default.GetAsync(constants.CURRENT_USER)))
        {
            await Shell.Current.GoToAsync($"//{nameof(HomePage)}");
        }
    }
}