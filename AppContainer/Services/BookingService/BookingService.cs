using AppContainer.Common;
using AppContainer.Dto.Booking;
using AppContainer.Models;
using Newtonsoft.Json;

namespace AppContainer.Services.BookingService
{
    public class BookingService : IBookingService
    {
        private readonly HttpClient httpClient;
        public BookingService()
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri($"{constants.URL}/booking/");
        }
        public Task<bool> CreateBookingAsync(AddBookingDto addBookingDto)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Booking>> GetBookingsAsync()
        {
            var response = await httpClient.GetStringAsync("");
            var objResponse = JsonConvert.DeserializeObject<ResponseApi<List<Booking>>>(response);

            return objResponse.Data;
        }

        public Task<List<Booking>> GetBookingsByAuthAsync()
        {
            throw new NotImplementedException();
        }
    }
}
