namespace TariffComparison.Models.Domain_Models
{
   public class Product
    {
        public string? Name { get; set; }
        public IProductCostCalculation? CalculateCost { get; set; }
    }
}
