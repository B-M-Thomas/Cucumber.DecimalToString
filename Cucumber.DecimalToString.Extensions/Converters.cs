using System.Linq;

namespace Cucumber.DecimalToString.Extensions
{
    public static class Converters
    {
        public static string ConvertToStringRepresentation(decimal number)
        {
            if (number % 1 != 0) // number has cents
            {
                var decimalParts = number.ToString().Split(".").Select(decimalString => long.Parse(decimalString)).ToArray();
                var left = decimalParts[0];
                var right = decimalParts[1];
                var leftResult = NumberToText(left);
                leftResult = leftResult != "" ? leftResult + Pluralise("DOLLAR", left) : leftResult;
                var rightResult = NumberToText(right);
                rightResult = rightResult != "" ? rightResult + Pluralise("CENT", right) : rightResult;

                if (!string.IsNullOrEmpty(leftResult) && !string.IsNullOrEmpty(rightResult)) return leftResult + " AND " + rightResult;
                else return leftResult + rightResult;
            }
            else
            {
                var result = NumberToText((long)number);
                return result != "" ? result + Pluralise("DOLLAR", (long)number) : "ZERO DOLLARS";
            }
        }

        private static string Pluralise(string input, long number)
        {
            if (number != 1 && number != -1) return input + "S";
            return input;
        }

        private static string Conjunctionise(string input, long number)
        {
            if (number > 99 || number == 0) return input;
            return "AND " + input;
        }

        private static string NumberToText(long n)
        {
            if (n < 0)
                return "MINUS " + NumberToText(-n);
            else if (n == 0)
                return "";
            else if (n <= 19)
                return new string[] {"ONE", "TWO", "THREE", "FOUR", "FIVE", "SIX", "SEVEN", "EIGHT",
                                "NINE", "TEN", "ELEVEN", "TWELVE", "THIRTEEN", "FOURTEEN", "FIFTEEN", "SIXTEEN",
                                "SEVENTEEN", "EIGHTEEN", "NINETEEN"}[n - 1] + " ";
            else if (n <= 99)
                return new string[] {"TWENTY", "THIRTY", "FORTY", "FIFTY", "SIXTY", "SEVENTY",
                                "EIGHTY", "NINETY"}[n / 10 - 2] + " " + NumberToText(n % 10);
            else if (n <= 199)
                return "ONE HUNDRED " + Conjunctionise(NumberToText(n % 100), n % 100);
            else if (n <= 999)
                return NumberToText(n / 100) + "HUNDRED " + Conjunctionise(NumberToText(n % 100), n% 100);
            else if (n <= 1999)
                return "ONE THOUSAND " + NumberToText(n % 1000);
            else if (n <= 999999)
                return NumberToText(n / 1000) + "THOUSAND " + Conjunctionise(NumberToText(n % 1000), n % 1000);
            else if (n <= 1999999)
                return "ONE MILLION " + NumberToText(n % 1000000);
            else if (n <= 999999999)
                return NumberToText(n / 1000000) + "MILLION " + Conjunctionise(NumberToText(n % 1000000), n % 1000000);
            else if (n <= 1999999999)
                return "ONE BILLION " + Conjunctionise(NumberToText(n % 1000000000), n % 1000000000);
            else
                return NumberToText(n / 1000000000) + "BILLION " + Conjunctionise(NumberToText(n % 1000000000), n % 1000000000);
        }

    }
}
