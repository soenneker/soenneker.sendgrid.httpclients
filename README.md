[![](https://img.shields.io/nuget/v/soenneker.sendgrid.httpclients.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.sendgrid.httpclients/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.sendgrid.httpclients/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.sendgrid.httpclients/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.sendgrid.httpclients.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.sendgrid.httpclients/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.sendgrid.httpclients/codeql.yml?style=for-the-badge&label=codeql)](https://github.com/soenneker/soenneker.sendgrid.httpclients/actions/workflows/codeql.yml)

# ![](https://user-images.githubusercontent.com/4441470/224455560-91ed3ee7-f510-4041-a8d2-3fc093025112.png) Soenneker.SendGrid.HttpClients

Provides a cached `HttpClient` for SendGrid mail, contacts, lists, templates, suppressions, statistics, settings, webhooks, and account APIs.

## Installation

```bash
dotnet add package Soenneker.SendGrid.HttpClients
```

## Configuration

```json
{
  "SendGrid": {
    "ApiKey": "SG.xxxxxxxxx"
  }
}
```

## Usage

```csharp
using Soenneker.SendGrid.HttpClients.Abstract;
using Soenneker.SendGrid.HttpClients.Registrars;

services.AddSendGridOpenApiHttpClientAsSingleton();

public sealed class SendGridScopeReader
{
    private readonly ISendGridOpenApiHttpClient _sendGrid;

    public SendGridScopeReader(ISendGridOpenApiHttpClient sendGrid)
    {
        _sendGrid = sendGrid;
    }

    public async Task<string> GetScopes(CancellationToken cancellationToken)
    {
        HttpClient client = await _sendGrid.Get(cancellationToken);
        return await client.GetStringAsync("v3/scopes", cancellationToken);
    }
}
```

The provider sends `Authorization: Bearer <api-key>` and targets `https://api.sendgrid.com/`. `SendGrid:ClientBaseUrl`, `SendGrid:AuthHeaderName`, and `SendGrid:AuthHeaderValueTemplate` can override those defaults for a proxy or compatible service; use `{token}` in the value template where the configured key should be inserted.
