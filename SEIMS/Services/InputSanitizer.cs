using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace SEIMS.Services
{
    /// <summary>Keyboard / text safety (Question 10): clean fields and format output safely.</summary>
    public static class InputSanitizer
    {
        public static string CleanText(string input)
        {
            return CleanText(input, 100);
        }

        /// <summary>Removes control characters and angle brackets, collapses spaces, trims and truncates.</summary>
        public static string CleanText(string input, int maxLength)
        {
            if (string.IsNullOrEmpty(input)) return "";

            var sb = new StringBuilder(input.Length);
            foreach (char ch in input)
            {
                if (char.IsControl(ch))
                {
                    sb.Append(' ');
                    continue;
                }
                if (ch == '<' || ch == '>') continue;
                sb.Append(ch);
            }

            string s = Regex.Replace(sb.ToString(), @"\s{2,}", " ").Trim();
            if (s.Length > maxLength) s = s.Substring(0, maxLength);
            return s;
        }

        /// <summary>Removes only control characters (keeps spacing - used for printing and XML).</summary>
        public static string StripControl(string input)
        {
            if (string.IsNullOrEmpty(input)) return "";
            var sb = new StringBuilder(input.Length);
            foreach (char ch in input)
            {
                if (!char.IsControl(ch)) sb.Append(ch);
            }
            return sb.ToString();
        }

        public static string Money(decimal value)
        {
            return "M " + value.ToString("N2", CultureInfo.InvariantCulture);
        }

        // ---------- KeyPress guards ----------
        public static void AllowDigitsOnly(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        public static void AllowDecimalOnly(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar) || char.IsDigit(e.KeyChar)) return;

            TextBox box = sender as TextBox;
            if (e.KeyChar == '.' && box != null && box.Text.IndexOf('.') < 0) return;

            e.Handled = true;
        }

        /// <summary>Cleans text that was pasted into a box (paste bypasses KeyPress).</summary>
        public static void SanitizeBox(TextBox box, int maxLength)
        {
            string cleaned = CleanText(box.Text, maxLength);
            if (cleaned != box.Text) box.Text = cleaned;
        }
    }
}
