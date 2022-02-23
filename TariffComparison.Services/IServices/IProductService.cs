using TariffComparison.Models.ResponseModels;

namespace TariffComparison.Services.IServices
{
    public interface IProductService
    {
        public List<ProductResponse> GetAll(double consumption);
    }
}
