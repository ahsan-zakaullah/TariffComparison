namespace TariffComparison.ExceptionHandling
{
    // Just for referencing Implement the custom exception and we can use where we want to show the meaningful message
    public class TariffComparisonException : Exception
    {
        public TariffComparisonException(string message)
            : base(message)
        {

        }

    }
}
