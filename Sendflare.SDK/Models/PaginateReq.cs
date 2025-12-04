using System.Text.Json.Serialization;

namespace Sendflare.SDK.Models
{
    /// <summary>
    /// Pagination request entity
    /// </summary>
    public class PaginateReq
    {
        [JsonPropertyName("page")]
        public int Page { get; set; }

        [JsonPropertyName("pageSize")]
        public int PageSize { get; set; }
    }
}

