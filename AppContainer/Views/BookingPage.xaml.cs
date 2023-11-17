using AppContainer.ViewModels;

namespace AppContainer.Views;

public partial class BookingPage : ContentPage
{
    private readonly BookingViewModel vm;
    public BookingPage(BookingViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
        this.vm = vm;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        BindingContext = new BookingViewModel(vm.bookingService);
    }
}