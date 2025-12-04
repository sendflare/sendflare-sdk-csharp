using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Sendflare.SDK.Models
{
    /// <summary>
    /// Get Contact list response entity
    /// </summary>
    public class ListContactResp : PaginateResp
    {
        [JsonPropertyName("data")]
        public List<ContactItem> Data { get; set; }
    }
}

