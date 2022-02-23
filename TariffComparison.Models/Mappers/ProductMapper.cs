using TariffComparison.Models.Domain_Models;
using TariffComparison.Models.ResponseModels;

namespace TariffComparison.Models.Mappers
{
    public static class ProductMapper
    {
        // Defining the mapper to map the domain models to response model
        public static ProductResponse Map(this Product source, int months, double consumptions)
        {
            return new ProductResponse
            {
                Name = source.Name,
                AnnualCost = source.CalculateCost?.CalculateCosts(months, consumptions) ?? double.NaN
            };
        }
    }
}
