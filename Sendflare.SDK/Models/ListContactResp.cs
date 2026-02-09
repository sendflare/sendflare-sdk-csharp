using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Sendflare.SDK.Models
{
    /// <summary>
    /// Get Contact list response entity
    /// </summary>
    public class ListContactResp
    {
        // CommonResponse fields
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

        // PaginateResp fields
        [JsonPropertyName("page")]
        public int Page { get; set; }

        [JsonPropertyName("pageSize")]
        public int PageSize { get; set; }

        [JsonPropertyName("totalCount")]
        public long TotalCount { get; set; }

        // Data wrapper with list
        [JsonPropertyName("data")]
        public ContactListData Data { get; set; }

        /// <summary>
        /// Nested data structure containing the contact list
        /// </summary>
        public class ContactListData
        {
            [JsonPropertyName("list")]
            public List<Dictionary<string, string>> List { get; set; }
        }
    }
}

