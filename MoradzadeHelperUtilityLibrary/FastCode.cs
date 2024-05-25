using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.Web.UI.DataVisualization.Charting;
using System.Runtime.CompilerServices;

namespace MoradzadeHelperUtilityLibrary
{
    public class FastCode
    {
        public static string Replace(string text, string[,] oldNewString)
        {
            return Replace(text, Enumerable.Range(0, oldNewString.GetLength(0)).Select(x => oldNewString[x, 0]).ToArray(), Enumerable.Range(0, oldNewString.GetLength(0)).Select(x => oldNewString[x, 1]).ToArray());
        }
        public static string Replace(string text, string[] oldString, string[] newString)
        {
            if (oldString.Length != newString.Length) return "oldString's length & newString's length must be same!";
            for (int i = 0; i < oldString.Length; i++)
            {
                text = text.Replace(oldString[i], newString[i]);
            }
            return text;
        }
        public static void Swap<Anything>(ref Anything changeThisVar, ref Anything withThisVar)
        {
            (changeThisVar, withThisVar) = (withThisVar, changeThisVar);
        }
        public static bool Contains(string text, string[] find)
        {
            if (text != "" && text != null && find.Length != 0 && find.Where(x => text.IndexOf(x) != -1).Count() > 0) return true;
            return false;
        }
        public static string[] ConvertStringToArray(string text, string[] seprator = null, bool splitNotSepratorsToo = false)
        {
            if (seprator == null) return Array.ConvertAll(text.ToCharArray(), Convert.ToString);

            List<string> collector = seprator.Where(x => x.Length > 1).ToList();
            List<string[]> encoded = new List<string[]>();

            bool isMoreThanOneChar = collector.Count() != 0 && Contains(text, collector.ToArray());

            if (isMoreThanOneChar)
            {
                ushort j = 0xD800;
                foreach (string i in collector)
                {
                    if (text.Contains(i) && j <= 0xDFFF)
                    {
                        string s = Convert.ToChar(j++).ToString();
                        encoded.Add(new string[2] { i, s });
                        text = text.Replace(i, s);
                        seprator[Array.IndexOf(seprator, i)] = s;
                    }
                    else if (j > 0xDFFF) throw new IndexOutOfRangeException();
                }
            }

            if (splitNotSepratorsToo)
            {
                if (isMoreThanOneChar) return ConvertStringToArray(text).Select(x => encoded.Select(y => y[1]).Contains(x) ? encoded[encoded.Select(y => y[1]).ToList().IndexOf(x)][0] : x).ToArray();
                return ConvertStringToArray(text);
            }
            else
            {
                int a = 0;
                bool nextStep = true;
                collector.Clear();
                foreach (char i in text)
                {
                    if (seprator.Contains(i.ToString()))
                    {
                        if (!nextStep) nextStep = true;
                        collector.Add(i.ToString());
                    }
                    else
                    {
                        if (nextStep)
                        {
                            nextStep = false;
                            a = collector.Count();
                            collector.Add(i.ToString());
                        }
                        else collector[a] += i;
                    }
                }
                if (isMoreThanOneChar) return collector.Select(x => encoded.Select(y => y[1]).Contains(x) ? encoded[encoded.Select(y => y[1]).ToList().IndexOf(x)][0] : x).ToArray();
                return collector.ToArray();
            }
        }
        public static string RomanNumeral(int number)
        {
            string[] Roman = new string[14] { "I", "V", "X", "L", "C", "D", "M", "I\u0305", "V\u0305", "X\u0305", "L\u0305", "C\u0305", "D\u0305", "M\u0305" };
            int[] Value = new int[14] { 1, 5, 10, 50, 100, 500, 1000, 1000, 5000, 10000, 50000, 100000, 500000, 1000000 };
            string s = "";

            if (number <= 0) return "Null";
            else if (number >= 4000000) return "Must be less than 4000000!";

            int a, b;
            for (int i = 0; ; i++)
            {
                int min = (int)Math.Pow(10, i), max = (int)Math.Pow(10, i + 1) - 1;
                if (min <= number && number <= max)
                {
                    b = i;
                    break;
                }
            }

            for (int i = b; i >= 0; i--)
            {
                a = (int)Math.Pow(10, i);
                b = number / a;
                number %= a;

                if (Value.Contains(b * a))
                {
                    s += Roman[Array.IndexOf(Value, b * a)];
                    continue;
                }

                if (b % 5 != 4)
                {
                    if (b % 5 == b) s += string.Concat(Enumerable.Repeat(Roman[Array.IndexOf(Value, a)], b));
                    else s += Roman[Array.IndexOf(Value, (b - b % 5) * a)] + string.Concat(Enumerable.Repeat(Roman[Array.LastIndexOf(Value, a)], b % 5));
                }
                else s += Roman[Array.LastIndexOf(Value, a)] + Roman[Array.IndexOf(Value, (b + (5 - b % 5)) * a)];
            }

            return s;
        }
        public static string MorseCode(string text)
        {
            string[,] morseCode = new string[79, 2] { { "A", "•–" }, { "B", "–•••" }, { "C", "–•–•" }, { "D", "–••" }, { "E", "•" }, { "F", "••–•" }, { "G", "––•" }, { "H", "••••" }, { "I", "••" }, { "J", "•–––" }, { "K", "–•–" }, { "L", "•–••" }, { "M", "––" }, { "N", "–•" }, { "O", "–––" }, { "P", "•––•" }, { "Q", "––•–" }, { "R", "•–•" }, { "S", "•••" }, { "T", "–" }, { "U", "••–" }, { "V", "•••–" }, { "W", "•––" }, { "X", "–••–" }, { "Y", "–•––" }, { "Z", "––••" }, { "0", "–––––" }, { "1", "•––––" }, { "2", "••–––" }, { "3", "•••––" }, { "4", "••••–" }, { "5", "•••••" }, { "6", "–••••" }, { "7", "––•••" }, { "8", "–––••" }, { "9", "––––•" }, { "آ", "–•" }, { "ا", "–•" }, { "ب", "•••–" }, { "پ", "•––•" }, { "ت", "•" }, { "ث", "•–•–" }, { "ج", "–––•" }, { "چ", "•–––" }, { "ح", "••••" }, { "خ", "–••–" }, { "د", "••–" }, { "ذ", "–•••" }, { "ر", "•–•" }, { "ز", "––••" }, { "ژ", "•––" }, { "س", "•••" }, { "ش", "––––" }, { "ص", "–•–•" }, { "ض", "••–••" }, { "ط", "–••" }, { "ظ", "––•–" }, { "ع", "–––" }, { "غ", "––••" }, { "ف", "•–••" }, { "ق", "–––•••" }, { "ک", "–•–" }, { "گ", "–•––" }, { "ل", "••–•" }, { "م", "––" }, { "ن", "•–" }, { "و", "––•" }, { "ه", "•" }, { "ی", "••" }, { "?", "••––••" }, { "؟", "••––••" }, { "!", "–•–•––" }, { ",", "––••––" }, { ";", "–•–•–•" }, { ":", "–––•••" }, { "+", "•–•–•" }, { "-", "–•••–" }, { "/", "–••–•" }, { "=", "–•••–" } }; //{ " ", "     " } { ".", "•–•–•–" } 
            string[] a = Enumerable.Range(0, morseCode.GetLength(0)).Select(x => morseCode[x, 0]).ToArray();
            string[] b = Enumerable.Range(0, morseCode.GetLength(0)).Select(x => morseCode[x, 1]).ToArray();

            text = text.Replace('.', '•').Replace('-', '–').Replace('_', '–').Replace("\r\n", " \r ").Replace("     ", " \n ").ToUpper();
            string element, s = "";

            string[] splitedTxet = text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i <= splitedTxet.Length - 1; ++i)
            {
                element = splitedTxet[i];

                if (i != 0 && splitedTxet[i - 1].IndexOfAny(new char[] { '•', '–' }) == -1 && element.IndexOfAny(new char[] { '•', '–' }) == -1) s += "    ";
                else if (i != 0 && ((splitedTxet[i - 1].IndexOfAny(new char[] { '•', '–' }) != -1 && element.IndexOfAny(new char[] { '•', '–' }) == -1) || (splitedTxet[i - 1].IndexOfAny(new char[] { '•', '–' }) == -1 && element.IndexOfAny(new char[] { '•', '–' }) != -1))) s += ' ';

                if (element == "\n") s += " ";
                else if (element == "\r") s += "\r\n";
                else if (element.IndexOfAny(new char[] { '•', '–' }) == -1)
                {
                    foreach (char c in element)
                    {
                        string txt = c.ToString();
                        if (a.Contains(txt))
                        {
                            s += morseCode[Array.IndexOf(a, txt), 1] + ' ';
                        }
                    }
                }
                else if (b.Contains(element)) s += morseCode[Array.IndexOf(b, element), 0];
            }
            return s.Replace('•', '.').Replace('–', '-');
        }
        public static string PassWordGuessor(string passWord, bool doShortCut = false, string passWordBase = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789@$#?~%+-_!=|&\\/*^'\"`.,:;<>[]{}()")
        {
            if (passWord == "") return "Wrong Input!";
            StringBuilder s = new StringBuilder("\0"), p = new StringBuilder(string.Concat(passWord.Reverse()));

            if (doShortCut) s = new StringBuilder('\0' + new String(passWordBase[0], passWord.Length - 1));

            Again:
            foreach (char c in passWordBase)
            {
                if (s[0] != '\0' && s.Equals(p))
                {
                    passWord = string.Concat(s.ToString().Reverse());
                    return $"After {Split(new MultiBaseNumber(passWord, passWordBase).DecodedNumber + 1, 3, ",")} guesses your password is {passWord}.";
                }
                s[0] = c;
            }
            s[0] = '\0';

            for (int i = 1; i <= s.Length - 1; i++)
            {
                if (s[i] != passWordBase.Last())
                {
                    s[i] = passWordBase[passWordBase.IndexOf(s[i]) + 1];
                    goto Again;
                }
                else s[i] = passWordBase[0];
            }
            s = s.Append(passWordBase[0]);
            goto Again;
        }
        public static List<string> CharGroupBy(char c)
        {
            List<string> s = new List<string>();
            if (c < 127) s.Add("IsASCII");
            if (char.IsLetterOrDigit(c)) s.Add("IsLetterOrDigit");
            if (char.IsLetter(c)) s.Add("IsLetter");
            if (char.IsLower(c)) s.Add("IsLower");
            if (char.IsUpper(c)) s.Add("IsUpper");
            if (char.IsDigit(c)) s.Add("IsDigit");
            if (char.IsNumber(c)) s.Add("IsNumber");
            if (char.IsControl(c)) s.Add("IsControl");
            if (char.IsPunctuation(c)) s.Add("IsPunctuation");
            if (char.IsSymbol(c)) s.Add("IsSymbol");
            if (char.IsSeparator(c)) s.Add("IsSeparator");
            if (char.IsWhiteSpace(c)) s.Add("IsWhiteSpace");
            if (char.IsSurrogate(c)) s.Add("IsSurrogate");
            if (char.IsLowSurrogate(c)) s.Add("IsLowSurrogate");
            if (char.IsHighSurrogate(c)) s.Add("IsHighSurrogate");

            return s;
        }
        public static string Split(object anyThing, int seprateLength, string seprator, char ifItWasntThere = '\0', bool fromEnd = true)
        {
            if (seprateLength <= 0) return "Wrong Length input";

            string s = anyThing.ToString(), f;
            List<string> Collector = new List<string>();
            for (int i = fromEnd ? s.Length - seprateLength : 0; ; i += fromEnd ? -seprateLength : seprateLength)
            {
                try
                {
                    Collector.Add(s.Substring(i, seprateLength));
                }
                catch (Exception)
                {
                    s = fromEnd ? s.Substring(0, i + seprateLength) : s.Substring(i);
                    if (s != "")
                    {
                        f = ifItWasntThere != '\0' ? new String(ifItWasntThere, seprateLength - s.Length) : "";
                        Collector.Add(fromEnd ? f + s : s + f);
                    }
                    break;
                }
            }
            if (fromEnd) Collector.Reverse();
            return string.Join(seprator, Collector);
        }
        public static string ReverseSplit(object anyThing, int splitLength, int reverseCount, bool fromEnd = false)
        {
            if (!(splitLength > 0 && reverseCount > 0)) return "Wrong number input!";

            string s = anyThing.ToString(), tmp;
            List<string> a = new List<string>(), b = new List<string>();
            for (int i = fromEnd ? s.Length - splitLength : 0; i < s.Length; i += fromEnd ? -splitLength : splitLength)
            {
                try
                {
                    tmp = s.Substring(i, splitLength);
                }
                catch (Exception)
                {
                    tmp = fromEnd ? s.Substring(0, i + splitLength) : s.Substring(i);
                }
                for (int j = 0; j < tmp.Length; j += reverseCount)
                {
                    try
                    {
                        b.Add(tmp.Substring(j, reverseCount));
                    }
                    catch (Exception)
                    {
                        b.Add(tmp.Substring(j));
                    }
                }
                b.Reverse();
                a.AddRange(b);
                b.Clear();
            }
            return string.Join(null, a);
        }
        public static string NumberFormatFixer(string text, char decimalPoint = '.')
        {
            if (IsNumber(text)) return text;
            string persianFontError = "۰۱۲۳۴۵۶۷۸۹٠١٢٣٤٥٦٧٨٩0123456789";
            int? a = null;
            if (text.Contains(decimalPoint)) a = text.IndexOf(decimalPoint);
            text = string.Concat(text.Replace(decimalPoint.ToString(), "").Where(x => char.IsDigit(x) && persianFontError.Contains(x)).Select(x => persianFontError.IndexOf(x) >= 20 ? x : persianFontError[persianFontError.IndexOf(x) % 10 + 20]));
            return a == null ? text : text.Insert((int)a, decimalPoint.ToString());
        }
        public static bool IsNumber(dynamic anyThing)
        {
            try
            {
                decimal a = Convert.ToDecimal(anyThing);
                return true;
            }
            catch (Exception)
            {
                try
                {
                    BigInteger a = BigInteger.Parse(Convert.ToString(anyThing));
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public static string OmitExtraZero(string number, string numberBase)
        {
            char[] s = numberBase.Replace("0", "").ToCharArray();
            int a = number.IndexOfAny(s);
            if (a == -1) return "0";
            else if (number.Contains('.'))
            {
                int b = number.IndexOf('.');
                int c = number.LastIndexOfAny(s);
                if (c < b) return number.Remove(b).Substring(a);
                else if (b < a) return "0." + number.Substring(b + 1, c - b);
                return number.Substring(a, c - a + 1);
            }
            return number.Substring(a);
        }
        public static bool IsPerfectNumber(double number)
        {
            string a = number.ToString();
            if (a.Contains('.'))
            {
                int b = a.Substring(a.IndexOf('.') + 1).Length;
                if (b % 2 != 0) return false;
                a = a.Replace(".", "");
            }
            if (Math.Sqrt(int.Parse(a)) % 1 == 0) return true;
            return false;
        }
        public static string GetDivisors(double number, bool doSort = true)
        {
            if (number == 0) return null;
            else if (number < 0) number = Math.Abs(number);
            List<double> divisors = new List<double>();
            for (int i = 1; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0)
                {
                    divisors.Add(i);
                    if (i != number / i) divisors.Add(number / i);
                }
            }
            if (doSort)
            {
                divisors.Sort();
                return string.Join(" ", divisors.ToArray());
            }
            else return string.Join(" ", divisors.ToArray());
        }
        public static string GetPrimeFactor(ulong number)
        {
            if (number == 1) return "1";
            else if (number <= 0) return "Wrong input!";
            List<ulong> divisors = new List<ulong>();
            string s;
            while (!IsPrime(number))
            {
                for (ushort i = 1; ; i++)
                {
                    uint primes = Prime(i);
                    if (number % primes == 0)
                    {
                        divisors.Add(primes);
                        number /= primes;
                        break;
                    }
                }
            }
            divisors.Add(number);
            var tmp = divisors.GroupBy(x => x).ToList(); // List<IGrouping<ulong, ulong>> tmp = divisors.GroupBy(x => x).ToList();
            s = "";
            foreach (var a in tmp)
            {
                if (a.Count() > 1) s += a.Key + "^" + a.Count();
                else s += a.Key;
                s += "*";
            }
            return s.Remove(s.Length - 1);
        }
        public static bool IsPrime(ulong number)
        {
            bool isPrime = true;
            if (number < 0) return false;

            if (number >= 2)
            {
                for (ulong divider = 2, maxDivider = (ulong)Math.Sqrt(number); divider <= maxDivider; ++divider)
                {
                    if (number % divider == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }
            }
            else isPrime = false;
            return isPrime;
        }
        public static uint Prime(ushort number) //دنباله ی اعداد اول
        {
            if (number <= 0) return 0;
            uint a = 1;
            while (number != 0)
            {
                a++;
                if (IsPrime(a)) number--;
            }
            return a;
        }
        public static List<ushort> GetPrime(ushort start, ushort end) //بین این اعداد چه اعدادی اول هستن
        {
            if (start < 0 || end < 0 || start >= end) return new List<ushort>(0);
            List<ushort> a = new List<ushort>();
            do
            {
                if (IsPrime(start)) a.Add(start);
                start++;
            } while (start != 0 && start <= end);
            return a;
        }
        public static BigInteger Fibonacci(short number) //دنباله ی فیبوناچی
        {
            if (number < 0) return BigInteger.Zero;
            BigInteger x = 0, y = 1, z = 1;
            for (short i = 1; i <= number; i++)
            {
                z = x + y;
                x = y;
                y = z;
            }
            return z;
        }
        public static List<BigInteger> GetFibonacci(int start, int end) //بین این اعداد چه اعدادی فیبوناچی هستن
        {
            if (start < 0 || end < 0) return new List<BigInteger>(0);

            BigInteger x = 0, y = 1, z;
            List<BigInteger> a = new List<BigInteger>();
            while (true)
            {
                z = x + y;
                x = y;
                y = z;
                if (start <= z && z <= end) a.Add(z);
                else if (z > end) break;
            }
            return a;
        }
        public static double Factorial(double number)
        {
            return (number > 0) ? new Chart().DataManipulator.Statistics.GammaFunction(number + 1) : double.NaN;
        }
        public static BigInteger Factorial(int number)
        {
            if (number < 0) return BigInteger.Zero;

            BigInteger b = 1;
            for (uint i = 2; i <= number; i++)
            {
                b *= i;
            }
            return b;
        }
        public static BigInteger Pow(BigInteger number, ulong power)
        {
            if (number != 0 || power != 0)
            {
                BigInteger c = 1;
                for (; power != 0; power--)
                {
                    c *= number;
                }
                return c;
            }
            else return BigInteger.Zero;
        }
        public static BigInteger Permutations(int n, int r) //ترتیب
        {
            if (n < 0 || r < 0) return BigInteger.Zero;
            return Factorial(n) / Factorial(n - r);
        }
        public static BigInteger Combination(int n, int r) //ترکیب
        {
            if (n < 0 || r < 0) return BigInteger.Zero;
            return Permutations(n, r) / Factorial(r);
        }
        public static int[] KhayyamPascalTriangle(byte row) //مثلث خیام-پاسکال
        {
            if (row == 1) return new int[] { 1, 1 };
            List<int> l = new List<int>();
            l.Add(1);
            for (int i = 1; i < row; i++)
            {
                l.Add((int)Combination(row, i));
            }
            l.Add(1);
            return l.ToArray();
        }
    }
}
