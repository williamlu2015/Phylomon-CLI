using System;
namespace PhylomonCLI
{
    public static class StringExtensions
    {
        public static String padAndTruncate
         (this String str,
          char paddingChar,
          int length)
        {
            return str.PadRight(length, paddingChar).Substring(0, length);
        }
    }
}
