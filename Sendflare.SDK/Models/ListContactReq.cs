using System.Text.Json.Serialization;

namespace Sendflare.SDK.Models
{
    /// <summary>
    /// Get Contact list request entity
    /// </summary>
    public class ListContactReq : PaginateReq
    {
        [JsonPropertyName("appId")]
        public string AppId { get; set; }
    }
}

