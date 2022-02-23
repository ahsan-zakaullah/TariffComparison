using TariffComparison.Models.Domain_Models;

namespace TariffComparison.Repository
{
    public interface IProductRepository
    {
        public IEnumerable<Product> GetAll();
    }
}
