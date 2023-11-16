using AppContainer.Views;

namespace AppContainer
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(HomePage), typeof(HomePage));
            Routing.RegisterRoute(nameof(DetailPage), typeof(DetailPage));
            Routing.RegisterRoute(nameof(AddContainer), typeof(AddContainer));
            Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
            Routing.RegisterRoute(nameof(LoadingPage), typeof(LoadingPage));
            Routing.RegisterRoute(nameof(BookingPage), typeof(BookingPage));
        }


        private void Button_Clicked_Logout(object sender, EventArgs e)
        {
            SecureStorage.Default.RemoveAll();
            Current.GoToAsync($"//{nameof(LoginPage)}");
        }
    }
}