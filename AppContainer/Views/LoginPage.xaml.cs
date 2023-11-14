using AppContainer.Models;
using Newtonsoft.Json;

namespace AppContainer.Views;

public partial class LoginPage : ContentPage
{
    public User _user;
	public LoginPage()
	{
		InitializeComponent();
	}
	public async void LoadUser()
	{
		HttpClient httpClient = new HttpClient();
        var Json = await httpClient.GetStringAsync($"{constants.URL}/auth/Login");
        AuthResponse auth = JsonConvert.DeserializeObject<AuthResponse>(Json);

    }
    private void Button_DangNhap(object sender, EventArgs e)
    {

    }
}