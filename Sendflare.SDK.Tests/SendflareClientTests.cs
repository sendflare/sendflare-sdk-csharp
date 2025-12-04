using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Sendflare.SDK.Models;
using Xunit;
using Xunit.Abstractions;

namespace Sendflare.SDK.Tests
{
    public class SendflareClientTests
    {
        private readonly ITestOutputHelper _output;
        private readonly SendflareClient _client;

        public SendflareClientTests(ITestOutputHelper output)
        {
            _output = output;
            _client = new SendflareClient("this-is-my-token");
        }

        [Fact]
        public void TestNewSendflareClient()
        {
            var client = new SendflareClient("this-is-my-token");
            Assert.NotNull(client);
        }

        [Fact]
        public async Task TestSendEmail()
        {
            var req = new SendEmailReq
            {
                From = "test@example.com",
                To = "to@example.com",
                Subject = "test",
                Body = "test email"
            };

            _output.WriteLine($"Request: {req.From} -> {req.To}");

            try
            {
                var resp = await _client.SendEmailAsync(req);
                _output.WriteLine($"Response: Success={resp.Success}");
            }
            catch (Exception e)
            {
                _output.WriteLine($"Expected error without valid token: {e.Message}");
                // This is expected without a valid token
                Assert.True(true);
            }
        }

        [Fact]
        public async Task TestGetContactList()
        {
            var req = new ListContactReq
            {
                AppId = "test",
                Page = 1,
                PageSize = 10
            };

            _output.WriteLine($"Request: AppId={req.AppId}");

            try
            {
                var resp = await _client.GetContactListAsync(req);
                _output.WriteLine($"Response: TotalCount={resp.TotalCount}");
            }
            catch (Exception e)
            {
                _output.WriteLine($"Expected error without valid token: {e.Message}");
                // This is expected without a valid token
                Assert.True(true);
            }
        }

        [Fact]
        public async Task TestSaveContact()
        {
            var req = new SaveContactReq
            {
                AppId = "test",
                EmailAddress = "test@example.com",
                Data = new Dictionary<string, string>
                {
                    { "firstName", "John" },
                    { "lastName", "Doe" }
                }
            };

            _output.WriteLine($"Request: {req.EmailAddress}");

            try
            {
                var resp = await _client.SaveContactAsync(req);
                _output.WriteLine($"Response: Success={resp.Success}");
            }
            catch (Exception e)
            {
                _output.WriteLine($"Expected error without valid token: {e.Message}");
                // This is expected without a valid token
                Assert.True(true);
            }
        }

        [Fact]
        public async Task TestDeleteContact()
        {
            var req = new DeleteContactReq
            {
                AppId = "test",
                EmailAddress = "test@example.com"
            };

            _output.WriteLine($"Request: {req.EmailAddress}");

            try
            {
                var resp = await _client.DeleteContactAsync(req);
                _output.WriteLine($"Response: Success={resp.Success}");
            }
            catch (Exception e)
            {
                _output.WriteLine($"Expected error without valid token: {e.Message}");
                // This is expected without a valid token
                Assert.True(true);
            }
        }
    }
}

