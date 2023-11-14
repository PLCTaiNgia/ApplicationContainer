using System.Text.Json.Serialization;

namespace AppContainer.Dto
{
    public class LoginDto
    {
        [JsonPropertyName("username")]
        public string UserName { get; set; }

        [JsonPropertyName("password")]
        public string Password { get; set; }
    }
}
