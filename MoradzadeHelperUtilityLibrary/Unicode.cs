using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoradzadeHelperUtilityLibrary
{
    public class Unicode
    {
        public class GetRange
        {
            public static string UTF16(params string[] justTwoCharNeeded)
            {
                if (justTwoCharNeeded.Select(x => x.Length).All(x => x != 2)) return "";
                string s = "";
                foreach (string i in justTwoCharNeeded)
                {
                    s += UTF16(i[0], i[1]);
                }
                return s;
            }
            public static string UTF16(char firstChar, char lastChar)
            {
                return UTF16((ushort)firstChar, (ushort)lastChar);
            }
            public static string UTF16(ushort min = 0x0, ushort max = 0xFFFF)
            {
                if (min > max) FastCode.Swap(ref min, ref max);
                string s = "";
                do
                {
                    s += (char)min++;
                } while (min != 0 && min <= max);
                return s;
            }
        }
    }
}
