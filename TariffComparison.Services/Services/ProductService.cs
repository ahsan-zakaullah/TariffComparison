using TariffComparison.Common;
using TariffComparison.Models.Mappers;
using TariffComparison.Models.ResponseModels;
using TariffComparison.Repository;
using TariffComparison.Services.IServices;

namespace TariffComparison.Services.Services
{
    public sealed class ProductService:IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public List<ProductResponse> GetAll(double consumption)
        {
             var result = _productRepository.GetAll();
            return result.Select(x => x.Map(Constants.CalculationBasedOnMonths, consumption))
                .OrderBy(x => x.AnnualCost).ToList();
        }
    }
}
