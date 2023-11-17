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

        public async Task<List<Booking>> GetBookingsByAuthAsync()
        {

            var token = await SecureStorage.Default.GetAsync(constants.TOKEN);

            if (httpClient.DefaultRequestHeaders.Authorization != null)
            {
                httpClient.DefaultRequestHeaders.Authorization = null;
            }

            httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

            var response = await httpClient.GetStringAsync("GetByUserId");
            var objResponse = JsonConvert.DeserializeObject<ResponseApi<List<Booking>>>(response);

            return objResponse.Data;
        }

        public async Task<bool> DeleteBookingAsync(string bookingId)
        {
            var token = await SecureStorage.Default.GetAsync(constants.TOKEN);

            if (httpClient.DefaultRequestHeaders.Authorization != null)
            {
                httpClient.DefaultRequestHeaders.Authorization = null;
            }

            httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

            var response = await httpClient.DeleteAsync($"{bookingId}");
            string resultString = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<ResponseApi<bool>>(resultString);
            return result.Success;
        }
    }
}
