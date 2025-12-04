using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web;
using Sendflare.SDK.Models;

namespace Sendflare.SDK
{
    /// <summary>
    /// Sendflare SDK Client
    /// </summary>
    public class SendflareClient : IDisposable
    {
        private const string BaseUrl = "https://api.sendflare.io";
        private const int RequestTimeout = 10; // seconds

        private readonly string _token;
        private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions _jsonOptions;

        /// <summary>
        /// Create a new Sendflare client instance
        /// </summary>
        /// <param name="token">API token</param>
        public SendflareClient(string token)
        {
            _token = token ?? throw new ArgumentNullException(nameof(token));
            
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(BaseUrl),
                Timeout = TimeSpan.FromSeconds(RequestTimeout)
            };

            _jsonOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
        }

        /// <summary>
        /// Send an email
        /// </summary>
        /// <param name="req">Send email request</param>
        /// <returns>Send email response</returns>
        public async Task<SendEmailResp> SendEmailAsync(SendEmailReq req)
        {
            var path = "/v1/send";
            return await MakeRequestAsync<SendEmailResp>(HttpMethod.Post, path, req);
        }

        /// <summary>
        /// Get contact list
        /// </summary>
        /// <param name="req">List contact request</param>
        /// <returns>List contact response</returns>
        public async Task<ListContactResp> GetContactListAsync(ListContactReq req)
        {
            var path = "/v1/contact";
            var query = HttpUtility.ParseQueryString(string.Empty);
            query["appId"] = req.AppId;
            query["page"] = req.Page.ToString();
            query["pageSize"] = req.PageSize.ToString();

            var url = $"{path}?{query}";
            return await MakeRequestAsync<ListContactResp>(HttpMethod.Get, url);
        }

        /// <summary>
        /// Create or update contact
        /// </summary>
        /// <param name="req">Save contact request</param>
        /// <returns>Save contact response</returns>
        public async Task<SaveContactResp> SaveContactAsync(SaveContactReq req)
        {
            var path = "/v1/contact";
            return await MakeRequestAsync<SaveContactResp>(HttpMethod.Post, path, req);
        }

        /// <summary>
        /// Delete a contact
        /// </summary>
        /// <param name="req">Delete contact request</param>
        /// <returns>Delete contact response</returns>
        public async Task<DeleteContactResp> DeleteContactAsync(DeleteContactReq req)
        {
            var path = "/v1/contact";
            var query = HttpUtility.ParseQueryString(string.Empty);
            query["appId"] = req.AppId;
            query["emailAddress"] = req.EmailAddress;

            var url = $"{path}?{query}";
            return await MakeRequestAsync<DeleteContactResp>(HttpMethod.Delete, url);
        }

        private async Task<T> MakeRequestAsync<T>(HttpMethod method, string path, object body = null)
        {
            using var request = new HttpRequestMessage(method, path);
            
            request.Headers.Add("Authorization", $"Bearer {_token}");

            if (body != null)
            {
                var json = JsonSerializer.Serialize(body, _jsonOptions);
                request.Content = new StringContent(json, Encoding.UTF8, "application/json");
            }

            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<T>(responseContent, _jsonOptions);
        }

        public void Dispose()
        {
            _httpClient?.Dispose();
        }
    }
}

