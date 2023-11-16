namespace AppContainer.Views;

public partial class LoadingPage : ContentPage
{
    public LoadingPage()
    {
        InitializeComponent();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        if (string.IsNullOrEmpty(await SecureStorage.Default.GetAsync(constants.CURRENT_USER)))
        {
            await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
        }
        else
        {
            await Shell.Current.GoToAsync($"//{nameof(HomePage)}");
        }
    }

}