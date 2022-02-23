using Xunit;
using Xunit.Abstractions;
using TariffComparison.Api.Test.Integration.Utilities;

namespace TariffComparison.Api.Test.Integration.Infrastructure
{
    [Collection("Integration Tests for DB")]
    public class IntegrationTestBase : IClassFixture<IntegrationTestFixture>
    {
        protected ITestOutputHelper Output { get; }

        private IntegrationTestFixture _fixture;
        protected IntegrationTestBase(IntegrationTestFixture integrationTestFixture, ITestOutputHelper output)
        {
            Output = output;
            _fixture = integrationTestFixture;
            // Here you can also configure the any DB you integrated with application.
        }

        public RequestBuilder NewRequest => new RequestBuilder(_fixture.HttpClient);
    }
}
