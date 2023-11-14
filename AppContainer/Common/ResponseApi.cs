using System.Text.Json.Serialization;

namespace AppContainer.Common
{
    public class ResponseApi<T>
    {
        [JsonPropertyName("Success")]
        public bool Success { get; set; }
        [JsonPropertyName("Message")]
        public string Message { get; set; }
        [JsonPropertyName("Data")]
        public T Data { get; set; }

    }
}
