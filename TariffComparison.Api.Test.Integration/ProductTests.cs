using AutoFixture;
using FluentAssertions;
using System.Collections.Generic;
using TariffComparison.Api.Test.Integration.Infrastructure;
using TariffComparison.Models.ResponseModels;
using Xunit;
using Xunit.Abstractions;

namespace TariffComparison.Api.Test.Integration
{
    public class ProductTests : IntegrationTestBase
    {
        public ProductTests(IntegrationTestFixture integrationTestFixture, ITestOutputHelper output) : base(integrationTestFixture, output)
        {
        }

        [Fact]
        public async void VerifyTheControllerEndPoint_ItShouldReturn_TotalCout()
        {
            //Setup
            var fixture = new Fixture();
            var consumption = fixture.Create<double>().ToString();

            var getProductRequest = (string consumption) => NewRequest
                     .AddRoute("Product/GetAll")
                     .AddQueryParams("consumption", consumption);

            // Exercise
            var response
                =  getProductRequest(consumption);
            // Verify
            var responses =await response.Get<List<ProductResponse>>();
            responses.Count.Should().Be(2);
        }

        [Fact]
        public async void VerifyTheTriffComparison_ItShouldBeSortedByAsc_TotalCost()
        {
            //Setup
            var fixture = new Fixture();
            var consumption = fixture.Create<double>().ToString();

            var getProductRequest = (string consumption) => NewRequest
                     .AddRoute("Product/GetAll")
                     .AddQueryParams("consumption", consumption);

            // Exercise
            var response
                = getProductRequest(consumption);
            // Verify
            var responses = await response.Get<List<ProductResponse>>();
            responses.Should().BeInAscendingOrder(x=>x.AnnualCost);
        }
    }
}
