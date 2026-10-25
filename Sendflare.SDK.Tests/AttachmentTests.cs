using System.Collections.Generic;
using System.Text.Json;
using Sendflare.SDK.Models;
using Xunit;

namespace Sendflare.SDK.Tests
{
    public class AttachmentTests
    {
        [Fact]
        public void SerializesSingleAndBatchAttachments()
        {
            var single = new SendEmailReq();
            var batch = new BatchSendEmailReq();
            foreach (var json in new[] { JsonSerializer.Serialize(single), JsonSerializer.Serialize(batch) })
            {
                using var document = JsonDocument.Parse(json);
                Assert.False(document.RootElement.TryGetProperty("attachments", out _));
            }
            var files = new List<SendAttachment> {
                new SendAttachment { Filename = "文件.bin", Content = new byte[] { 0, 255, 1, 128 } },
                new SendAttachment { Filename = "logo.png", Content = new byte[] { 104, 101, 108, 108, 111 }, ContentType = "image/png", ContentId = "logo", Disposition = "inline" }
            };
            single.Attachments = files;
            batch.Attachments = files;
            foreach (var json in new[] { JsonSerializer.Serialize(single), JsonSerializer.Serialize(batch) })
            {
                using var document = JsonDocument.Parse(json);
                var attachments = document.RootElement.GetProperty("attachments");
                Assert.Equal(2, attachments.GetArrayLength());
                Assert.Equal("AP8BgA==", attachments[0].GetProperty("content").GetString());
                Assert.Equal("文件.bin", attachments[0].GetProperty("filename").GetString());
                Assert.False(attachments[0].TryGetProperty("contentType", out _));
                Assert.False(attachments[0].TryGetProperty("contentId", out _));
                Assert.False(attachments[0].TryGetProperty("disposition", out _));
                Assert.Equal("aGVsbG8=", attachments[1].GetProperty("content").GetString());
                Assert.Equal("image/png", attachments[1].GetProperty("contentType").GetString());
                Assert.Equal("logo", attachments[1].GetProperty("contentId").GetString());
                Assert.Equal("inline", attachments[1].GetProperty("disposition").GetString());
            }
        }
    }
}
