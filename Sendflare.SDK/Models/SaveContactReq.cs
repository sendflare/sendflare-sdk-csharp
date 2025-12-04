using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Sendflare.SDK.Models
{
    /// <summary>
    /// Save contact request entity
    /// </summary>
    public class SaveContactReq
    {
        [JsonPropertyName("appId")]
        public string AppId { get; set; }

        [JsonPropertyName("emailAddress")]
        public string EmailAddress { get; set; }

        [JsonPropertyName("data")]
        public Dictionary<string, string> Data { get; set; }
    }
}

