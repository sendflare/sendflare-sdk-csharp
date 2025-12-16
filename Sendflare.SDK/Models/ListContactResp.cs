using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Sendflare.SDK.Models
{
    /// <summary>
    /// Get Contact list response entity
    /// </summary>
    public class ListContactResp : PaginateResp
    {
        [JsonPropertyName("list")]
        public List<Map<String, String>> List { get; set; }
    }
}

