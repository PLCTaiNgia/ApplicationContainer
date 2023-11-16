using AppContainer.Dto.Booking;
using AppContainer.Models;

namespace AppContainer.Services.BookingService
{
    public interface IBookingService
    {
        Task<List<Booking>> GetBookingsAsync();
        Task<List<Booking>> GetBookingsByAuthAsync();
        Task<bool> CreateBookingAsync(AddBookingDto addBookingDto);
    }
}
