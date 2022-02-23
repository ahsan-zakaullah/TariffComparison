using TariffComparison.Models.Domain_Models;

namespace TariffComparison.Repository
{
    public sealed class ProductRepository : IProductRepository
    {
        // Just seeding the values for both products. 
        public IEnumerable<Product> GetAll()
        {
            yield return new Product
            {
                Name = "Basic electricity tariff",
                CalculateCost = new BasicProduct
                {
                    BaseCosts = 5,
                    ConsumptionCostsPerUnit = 0.22
                }
            };

            yield return new Product
            {
                Name = "Packaged tariff",
                CalculateCost = new PackagedProduct
                {
                    BaseCosts = 800,
                    BaseCostsLimit = 4000,
                    ConsumptionCostsPerUnit = 0.30
                }
            };
        }
    }
}
