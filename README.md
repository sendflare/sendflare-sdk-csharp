# sendflare-sdk-csharp

The SDK for sendflare service written in C#.

## Requirements

- .NET Standard 2.0 or higher
- .NET Framework 4.6.1+ / .NET Core 2.0+ / .NET 5.0+

## Installation

Install via NuGet Package Manager:

```bash
dotnet add package Sendflare.SDK
```

Or via Package Manager Console:

```powershell
Install-Package Sendflare.SDK
```

## Quick Start

```csharp
using Sendflare.SDK;
using Sendflare.SDK.Models;

var client = new SendflareClient("your-api-token");

var req = new SendEmailReq
{
    From = "test@example.com",
    To = "to@example.com",
    Subject = "Hello",
    Body = "Test email"
};

try
{
    var response = await client.SendEmailAsync(req);
    Console.WriteLine($"Email sent successfully: {response.Success}");
}
catch (Exception ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}
```

## Usage Examples

### Send Email

```csharp
using Sendflare.SDK;
using Sendflare.SDK.Models;

var client = new SendflareClient("your-api-token");

var req = new SendEmailReq
{
    From = "sender@example.com",
    To = "recipient@example.com",
    Subject = "Subject Here",
    Body = "Email body content"
};

var response = await client.SendEmailAsync(req);
if (response.Success)
{
    Console.WriteLine("Email sent successfully!");
}
```

### Get Contact List

```csharp
using Sendflare.SDK;
using Sendflare.SDK.Models;

var client = new SendflareClient("your-api-token");

var req = new ListContactReq
{
    AppId = "your-app-id",
    Page = 1,
    PageSize = 10
};

var response = await client.GetContactListAsync(req);
Console.WriteLine($"Total contacts: {response.TotalCount}");

foreach (var contact in response.Data)
{
    Console.WriteLine($"Email: {contact.EmailAddress}");
}
```

### Save Contact

```csharp
using Sendflare.SDK;
using Sendflare.SDK.Models;
using System.Collections.Generic;

var client = new SendflareClient("your-api-token");

var req = new SaveContactReq
{
    AppId = "your-app-id",
    EmailAddress = "john@example.com",
    Data = new Dictionary<string, string>
    {
        { "firstName", "John" },
        { "lastName", "Doe" },
        { "company", "Acme Corp" }
    }
};

var response = await client.SaveContactAsync(req);
if (response.Success)
{
    Console.WriteLine("Contact saved successfully!");
}
```

### Delete Contact

```csharp
using Sendflare.SDK;
using Sendflare.SDK.Models;

var client = new SendflareClient("your-api-token");

var req = new DeleteContactReq
{
    EmailAddress = "john@example.com",
    AppId = "your-app-id"
};

var response = await client.DeleteContactAsync(req);
if (response.Success)
{
    Console.WriteLine("Contact deleted successfully!");
}
```

## API Reference

### SendflareClient

#### Constructor

```csharp
public SendflareClient(string token)
```

Create a new Sendflare client instance.

**Parameters:**
- `token` - Your Sendflare API token

#### Methods

##### SendEmailAsync

```csharp
public async Task<SendEmailResp> SendEmailAsync(SendEmailReq req)
```

Send an email.

**Parameters:**
- `req` - Send email request
  - `From` - Sender email address
  - `To` - Recipient email address
  - `Subject` - Email subject
  - `Body` - Email body content

**Returns:** `Task<SendEmailResp>`

##### GetContactListAsync

```csharp
public async Task<ListContactResp> GetContactListAsync(ListContactReq req)
```

Get contact list with pagination.

**Parameters:**
- `req` - List contact request
  - `AppId` - Application ID
  - `Page` - Page number
  - `PageSize` - Items per page

**Returns:** `Task<ListContactResp>`

##### SaveContactAsync

```csharp
public async Task<SaveContactResp> SaveContactAsync(SaveContactReq req)
```

Create or update a contact.

**Parameters:**
- `req` - Save contact request
  - `AppId` - Application ID
  - `EmailAddress` - Contact email address
  - `Data` - Contact data (Dictionary<string, string>)

**Returns:** `Task<SaveContactResp>`

##### DeleteContactAsync

```csharp
public async Task<DeleteContactResp> DeleteContactAsync(DeleteContactReq req)
```

Delete a contact.

**Parameters:**
- `req` - Delete contact request
  - `EmailAddress` - Contact email address
  - `AppId` - Application ID

**Returns:** `Task<DeleteContactResp>`

## Model Classes

### Request Models

- `SendEmailReq` - Send email request
- `ListContactReq` - Get contact list request
- `SaveContactReq` - Save contact request
- `DeleteContactReq` - Delete contact request
- `PaginateReq` - Pagination request (base class)

### Response Models

- `SendEmailResp` - Send email response
- `ListContactResp` - Get contact list response
- `SaveContactResp` - Save contact response
- `DeleteContactResp` - Delete contact response
- `CommonResponse<T>` - Common response (base class)
- `PaginateResp` - Pagination response (base class)
- `ContactItem` - Contact information

## Building from Source

```bash
# Restore dependencies
dotnet restore

# Build the solution
dotnet build

# Run tests
dotnet test

# Pack NuGet package
dotnet pack -c Release
```

## Testing

Run tests with:

```bash
dotnet test
```

## Error Handling

All async methods may throw exceptions. It's recommended to wrap calls in try-catch blocks:

```csharp
try
{
    var response = await client.SendEmailAsync(req);
    // Handle success
}
catch (HttpRequestException ex)
{
    // Handle HTTP errors
    Console.WriteLine($"HTTP error: {ex.Message}");
}
catch (Exception ex)
{
    // Handle other errors
    Console.WriteLine($"Error: {ex.Message}");
}
```

## Async/Await Pattern

All API methods are asynchronous and return `Task<T>`. Make sure to use `await` when calling them:

```csharp
// Good
var response = await client.SendEmailAsync(req);

// Don't do this
var response = client.SendEmailAsync(req).Result; // May cause deadlocks
```

## Disposing

The `SendflareClient` implements `IDisposable`. It's recommended to use it with `using` statement:

```csharp
using (var client = new SendflareClient("your-token"))
{
    var response = await client.SendEmailAsync(req);
}
// Client is automatically disposed here
```

## Dependencies

- System.Text.Json (>= 6.0.0) - JSON serialization

## Documentation

For more information, visit: [https://docs.sendflare.io](https://docs.sendflare.io)

## License

[MIT](./LICENSE)

