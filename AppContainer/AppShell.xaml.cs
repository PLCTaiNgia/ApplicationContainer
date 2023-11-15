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
        }


        private void Button_Clicked_Logout(object sender, EventArgs e)
        {
            
        }
    }
}