namespace TariffComparison.Models.Domain_Models
{
    public interface IProductCostCalculation
    {
        double CalculateCosts(int months, double consumption);
    }
}
