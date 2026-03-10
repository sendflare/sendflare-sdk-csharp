using System.Text.Json.Serialization;

namespace Sendflare.SDK.Models
{
    /// <summary>
    /// Send Email request entity
    /// </summary>
    public class SendEmailReq
    {
        [JsonPropertyName("from")]
        public string From { get; set; }

        [JsonPropertyName("to")]
        public string To { get; set; }

        [JsonPropertyName("subject")]
        public string Subject { get; set; }

        [JsonPropertyName("body")]
        public string Body { get; set; }

        [JsonPropertyName("cc")]
        public List<string> CC { get; set; }

        [JsonPropertyName("bcc")]
        public List<string> BCC { get; set; }
    }
}

