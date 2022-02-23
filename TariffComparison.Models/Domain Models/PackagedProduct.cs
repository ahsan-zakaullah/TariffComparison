using TariffComparison.Common;
using TariffComparison.ExceptionHandling;

namespace TariffComparison.Models.Domain_Models
{
    public class PackagedProduct : IProductCostCalculation
    {
        public double BaseCostsLimit { get; set; }
        public double BaseCosts { get; set; }
        public double ConsumptionCostsPerUnit { get; set; }
        public double CalculateCosts(int months, double consumption)
        {

            if (months < 0)
                throw new TariffComparisonException("Period must non negative");

            if (consumption < 0)
                throw new TariffComparisonException("Consumption must non negative");

            double baseCosts = BaseCosts / Constants.CalculationBasedOnMonths * months;

            if (consumption / months <= BaseCostsLimit / Constants.CalculationBasedOnMonths)
                return baseCosts;

            double baseCostsLimit = BaseCostsLimit / Constants.CalculationBasedOnMonths * months;
            return baseCosts + (consumption - baseCostsLimit) * ConsumptionCostsPerUnit;
        }
    }
}
