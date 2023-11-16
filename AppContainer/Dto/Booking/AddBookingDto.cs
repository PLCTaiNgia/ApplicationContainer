using System.Text.Json.Serialization;

namespace AppContainer.Dto.Booking
{
    public class AddBookingDto
    {
        [JsonPropertyName("ContainerId")]
        public string ContainerId { get; set; }
    }
}
