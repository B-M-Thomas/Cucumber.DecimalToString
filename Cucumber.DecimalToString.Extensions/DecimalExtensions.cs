namespace Cucumber.DecimalToString.Extensions
{
    public static class DecimalExtensions
    {
        public static string ToStringRepresentation(this decimal d) { return Converters.ConvertToStringRepresentation(d); }
    }
}
