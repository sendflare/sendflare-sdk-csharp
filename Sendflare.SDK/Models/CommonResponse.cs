using System.Text.Json.Serialization;

namespace Sendflare.SDK.Models
{
    /// <summary>
    /// Common response entity
    /// </summary>
    public class CommonResponse<T>
    {
        [JsonPropertyName("requestId")]
        public string RequestId { get; set; }

        [JsonPropertyName("code")]
        public int Code { get; set; }

        [JsonPropertyName("success")]
        public bool Success { get; set; }

        [JsonPropertyName("message")]
        public string Message { get; set; }

        [JsonPropertyName("ts")]
        public long Ts { get; set; }

        [JsonPropertyName("data")]
        public T Data { get; set; }
    }
}

