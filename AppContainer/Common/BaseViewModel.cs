using CommunityToolkit.Mvvm.ComponentModel;

namespace AppContainer.Common
{
    public abstract partial class BaseViewModel : ObservableObject
    {
        [ObservableProperty]
        private bool _isBusy;

        [ObservableProperty]
        private bool _title;
    }
}
