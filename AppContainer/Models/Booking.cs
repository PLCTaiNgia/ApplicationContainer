using System.Text.Json.Serialization;

namespace AppContainer.Models
{
    public class Booking
    {
        [JsonPropertyName("Id")]
        public string Id { get; set; }

        [JsonPropertyName("UserId")]
        public int UserId { get; set; }

        [JsonPropertyName("User")]
        public User User { get; set; }

        [JsonPropertyName("ContainerId")]
        public string ContainerId { get; set; }

        [JsonPropertyName("Container")]
        public Container Container { get; set; }
    }
}
