using AppContainer.Common;
using AppContainer.Models;
using AppContainer.Services.BookingService;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace AppContainer.ViewModels
{
    public partial class BookingViewModel : BaseViewModel
    {
        public readonly IBookingService bookingService;

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
            Task.Run(() => GetBookingsAsync());
        }

        private async Task GetBookingsAsync()
        {
            Bookings = await bookingService.GetBookingsByAuthAsync();
        }

        [RelayCommand]
        async Task OnDelete(string id)
        {
            var result = await bookingService.DeleteBookingAsync(id);
            if (result)
            {
                await AppToast.ShowToastSuccessAsync("Xóa thành công");
                await GetBookingsAsync();
            }
            else
            {
                await AppToast.ShowToastErrorAsync("Xóa thất bại");
            }
        }
    }
}
