using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Net.Http;

namespace TariffComparison.Api.Test.Integration.Infrastructure
{
    public class IntegrationTestFixture : IDisposable
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public IntegrationTestFixture()
        {
            _factory = new CustomWebApplicationFactory<Startup>();
        }
        public void Dispose()
        {
            _factory.Dispose();
        }

        public HttpClient HttpClient => _factory.CreateClient();
    }
}
