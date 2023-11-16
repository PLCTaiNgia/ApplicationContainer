using AppContainer.Common;
using AppContainer.Models;
using AppContainer.Services.BookingService;
using CommunityToolkit.Mvvm.ComponentModel;

namespace AppContainer.ViewModels
{
    public partial class BookingViewModel : BaseViewModel
    {
        private readonly IBookingService bookingService;

        [ObservableProperty]
        private List<Booking> bookings;

        [ObservableProperty]
        private string id;

        [ObservableProperty]
        private int userId;

        [ObservableProperty]
        private User user;

        [ObservableProperty]
        private string containerId;

        [ObservableProperty]
        private Container container;

        public BookingViewModel(IBookingService bookingService)
        {
            this.bookingService = bookingService;
            _ = GetBookingsAsync();
        }

        private async Task GetBookingsAsync()
        {
            Bookings = await bookingService.GetBookingsAsync();
        }
    }
}
