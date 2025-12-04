using System.Text.Json.Serialization;

namespace Sendflare.SDK.Models
{
    /// <summary>
    /// Contact info entity
    /// </summary>
    public class ContactItem
    {
        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("emailAddress")]
        public string EmailAddress { get; set; }

        [JsonPropertyName("language")]
        public string Language { get; set; }

        [JsonPropertyName("firstName")]
        public string FirstName { get; set; }

        [JsonPropertyName("lastName")]
        public string LastName { get; set; }

        [JsonPropertyName("phoneNumber")]
        public string PhoneNumber { get; set; }

        [JsonPropertyName("birthday")]
        public string Birthday { get; set; }

        [JsonPropertyName("company")]
        public string Company { get; set; }

        [JsonPropertyName("vipLevel")]
        public int VipLevel { get; set; }

        [JsonPropertyName("amount")]
        public string Amount { get; set; }
    }
}

