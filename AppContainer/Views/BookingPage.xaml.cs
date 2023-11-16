using AppContainer.ViewModels;

namespace AppContainer.Views;

public partial class BookingPage : ContentPage
{
    public BookingPage(BookingViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}