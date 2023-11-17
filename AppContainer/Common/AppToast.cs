using CommunityToolkit.Maui.Alerts;

namespace AppContainer.Common
{
    public static class AppToast
    {
        public static async Task ShowToastSuccessAsync(string message, string actionButtonText = "OK")
        {
            var snackBar = Snackbar.Make(message, actionButtonText: actionButtonText, visualOptions: new CommunityToolkit.Maui.Core.SnackbarOptions
            {
                BackgroundColor = Colors.Green,
                TextColor = Colors.White,
                ActionButtonTextColor = Colors.White,
            });

            await snackBar.Show();
        }

        public static async Task ShowToastErrorAsync(string message, string actionButtonText = "OK")
        {
            var snackBar = Snackbar.Make(message, actionButtonText: actionButtonText, visualOptions: new CommunityToolkit.Maui.Core.SnackbarOptions
            {
                BackgroundColor = Color.FromHex("FE0000"),
                TextColor = Colors.White,
                ActionButtonTextColor = Colors.White,
            });

            await snackBar.Show();
        }
        public static async Task ShowToastWarnAsync(string message, string actionButtonText = "OK")
        {
            var snackBar = Snackbar.Make(message, actionButtonText: actionButtonText, visualOptions: new CommunityToolkit.Maui.Core.SnackbarOptions
            {
                BackgroundColor = Color.FromHex("FFA33C"),
                TextColor = Colors.White,
                ActionButtonTextColor = Colors.White,
            });

            await snackBar.Show();
        }
    }
}
