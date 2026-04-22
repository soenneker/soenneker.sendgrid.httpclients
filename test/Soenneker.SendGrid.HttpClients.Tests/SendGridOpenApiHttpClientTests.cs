using Soenneker.SendGrid.HttpClients.Abstract;
using Soenneker.Tests.HostedUnit;

namespace Soenneker.SendGrid.HttpClients.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public sealed class SendGridOpenApiHttpClientTests : HostedUnitTest
{
    private readonly ISendGridOpenApiHttpClient _httpclient;

    public SendGridOpenApiHttpClientTests(Host host) : base(host)
    {
        _httpclient = Resolve<ISendGridOpenApiHttpClient>(true);
    }

    [Test]
    public void Default()
    {

    }
}
