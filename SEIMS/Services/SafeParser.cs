using System.Globalization;

namespace SEIMS.Services
{
    /// <summary>Safe type conversions (Question 5).</summary>
    public static class SafeParser
    {
        // "global" (static) variable: lives for the whole run of the program
        public static int TotalParseFailures { get; private set; }

        /// <summary>int.TryParse version: never throws.</summary>
        public static bool TryInt(string text, out int value)
        {
            return int.TryParse((text ?? "").Trim(), NumberStyles.Integer, CultureInfo.InvariantCulture, out value);
        }

        /// <summary>Convert.ToInt32 version: wrapped in try / catch / finally with specific exceptions.</summary>
        public static int ToInt32Strict(string text, string fieldName)
        {
            int result = 0;                       // local variable: only exists inside this method
            bool ok = false;
            try
            {
                result = Convert.ToInt32((text ?? "").Trim(), CultureInfo.InvariantCulture);
                ok = true;
            }
            catch (FormatException)
            {
                TotalParseFailures++;
                throw new FormatException(fieldName + " must be a whole number (you typed '" + text + "').");
            }
            catch (OverflowException)
            {
                TotalParseFailures++;
                throw new FormatException(fieldName + " is too large or too small.");
            }
            finally
            {
                // runs whether or not an exception happened
                System.Diagnostics.Debug.WriteLine("ToInt32Strict(" + fieldName + ") ok=" + ok);
            }
            return result;
        }

        public static decimal ToDecimalStrict(string text, string fieldName)
        {
            decimal value;
            if (!decimal.TryParse((text ?? "").Trim(), NumberStyles.Number, CultureInfo.InvariantCulture, out value))
            {
                TotalParseFailures++;
                throw new FormatException(fieldName + " must be a number such as 12.50 (you typed '" + text + "').");
            }
            return value;
        }
    }
}
