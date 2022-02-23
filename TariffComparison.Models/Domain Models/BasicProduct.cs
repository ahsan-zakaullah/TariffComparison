using TariffComparison.ExceptionHandling;

namespace TariffComparison.Models.Domain_Models
{
    public class BasicProduct : IProductCostCalculation
    {
        public double BaseCosts { get; set; }
        public double ConsumptionCostsPerUnit { get; set; }
        // Calculate the cost based on the product type
        // As i am defining an interface which every product will implement that and calculate it according to their formula
        public double CalculateCosts(int months, double consumption)
        {
            if (consumption < 0)
                throw new TariffComparisonException("Consumption must non negative");

            return BaseCosts * months + ConsumptionCostsPerUnit * consumption;
        }
    }
}
