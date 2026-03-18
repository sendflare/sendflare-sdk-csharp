using System.Text.Json.Serialization;

namespace Sendflare.SDK.Models
{
    /// <summary>
    /// Batch Send Email request entity
    /// </summary>
    public class BatchSendEmailReq
    {
        [JsonPropertyName("from")]
        public string From { get; set; }

        [JsonPropertyName("to")]
        public List<string> To { get; set; }

        [JsonPropertyName("subject")]
        public string Subject { get; set; }

        [JsonPropertyName("body")]
        public string Body { get; set; }

        [JsonPropertyName("cc")]
        public List<string> CC { get; set; }

        [JsonPropertyName("bcc")]
        public List<string> BCC { get; set; }

        [JsonPropertyName("replyTo")]
        public List<string> ReplyTo { get; set; }
    }
}

