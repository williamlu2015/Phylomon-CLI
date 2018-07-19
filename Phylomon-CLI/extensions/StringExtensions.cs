using System;
namespace PhylomonCLI
{
    public static class StringExtensions
    {
        public static String truncateAndCenter
         (this String str,
          int length)
        {
            if (str.Length < length) {
                // need to pad
                int totalWhitespace = length - str.Length;
                int leftPadding = (int) Math.Floor(totalWhitespace / 2.0);

                return str.PadLeft(leftPadding + str.Length).PadRight(length);
            } else {
                //just truncate and return
                return str.Substring(0, length);
            }
        }
    }
}
