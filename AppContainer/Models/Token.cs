using System.Text.Json.Serialization;

namespace AppContainer.Models
{
    public class Token
    {
        [JsonPropertyName("accessToken")]
        public string AccessToken { get; set; }
    }
}
