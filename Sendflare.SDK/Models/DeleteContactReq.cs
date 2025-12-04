using System.Text.Json.Serialization;

namespace Sendflare.SDK.Models
{
    /// <summary>
    /// Delete a contact request entity
    /// </summary>
    public class DeleteContactReq
    {
        [JsonPropertyName("emailAddress")]
        public string EmailAddress { get; set; }

        [JsonPropertyName("appId")]
        public string AppId { get; set; }
    }
}

