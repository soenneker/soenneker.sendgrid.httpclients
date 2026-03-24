using Soenneker.SendGrid.HttpClients.Abstract;
using Soenneker.Tests.FixturedUnit;
using Xunit;

namespace Soenneker.SendGrid.HttpClients.Tests;

[Collection("Collection")]
public sealed class SendGridOpenApiHttpClientTests : FixturedUnitTest
{
    private readonly ISendGridOpenApiHttpClient _httpclient;

    public SendGridOpenApiHttpClientTests(Fixture fixture, ITestOutputHelper output) : base(fixture, output)
    {
        _httpclient = Resolve<ISendGridOpenApiHttpClient>(true);
    }

    [Fact]
    public void Default()
    {

    }
}
