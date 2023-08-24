namespace InteractHealthProDatabase.MyTools
{
    public class MyFormatter
    {
        /// <summary>
        /// Formats a name to Title Case
        /// </summary>
        internal static string FormatNameToTitleCase(string name)
        {
            string[] words = name.Split(' ');
            string outStr = "";
            foreach (string s in words)
            {
                outStr += s.ToLower().Substring(0, 1).ToUpper() + s.ToLower().Substring(1) + " ";
            }
            return outStr.Trim();
        }

        /// <summary>
        /// Formats a phone number to (xxx) xxx-xxxx OR xxx-xxxx
        /// </summary>
        internal static string? FormatPhoneNumber(string? phoneNumber)
        {
            return phoneNumber == null ? null
            : phoneNumber.Length == 10 ? $"({phoneNumber.Substring(0, 3)}) {phoneNumber.Substring(3, 3)}-{phoneNumber.Substring(6)}"
            : phoneNumber.Length == 7 ? $"{phoneNumber.Substring(0, 3)}-{phoneNumber.Substring(3)}"
            : phoneNumber;
        }

        /// <summary>
        /// Formats a postal code to xxx xxx
        /// </summary>
        internal static string? FormatPostalCode(string? postalCode)
        {
            return postalCode == null ? null
            : postalCode.Length == 6 ? $"{postalCode.ToUpper().Substring(0, 3)} {postalCode.Substring(3)}"
            : postalCode.ToUpper();
        }

        /// <summary>
        /// Removes all non-numeric characters from a phone number
        /// </summary>
        internal static string? Strip(string? phoneNumber)
        {
            return (phoneNumber == null) ? null
            : phoneNumber.Replace(".", string.Empty).Replace("(", string.Empty).Replace(")", string.Empty).Replace("-", string.Empty).Replace(" ", string.Empty);
        }
    }
}