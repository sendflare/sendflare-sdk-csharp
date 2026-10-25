using System.Text.Json.Serialization;

namespace Sendflare.SDK.Models
{
    /// <summary>Attachment bytes are serialized as a Base64 string.</summary>
    public class SendAttachment
    {
        [JsonPropertyName("filename")]
        public string Filename { get; set; }

        [JsonPropertyName("content")]
        public byte[] Content { get; set; }

        [JsonPropertyName("contentType")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string ContentType { get; set; }

        [JsonPropertyName("contentId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string ContentId { get; set; }

        [JsonPropertyName("disposition")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Disposition { get; set; }
    }
}
