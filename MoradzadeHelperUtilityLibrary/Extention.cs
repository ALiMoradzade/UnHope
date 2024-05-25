using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MoradzadeHelperUtilityLibrary
{
    public static class Extention
    {
        public static string GenerateNumber(this Random r, uint length)
        {
            if (length == 0) throw new ArgumentOutOfRangeException();
            string s = "";
            for (; length > 0; length--)
            {
                s = s.InsertRandom(r.Next(10).ToString());
            }
            return s;
        }
        public static long RandomSeed(this Random r)
        {
            sbyte[] sign = { 1, 1, 1 };
            for (byte i = 0; i < 3; i++)
            {
                if (r.Next() % 2 != 0) sign[i] = -1;
            }
            return Math.Abs(sign[0] * Environment.TickCount + sign[1] * DateTime.Now.Ticks + sign[2] * DateTime.Now.Millisecond);
        }
        public static string InsertRandom(this string s, dynamic text)
        {
            return s.Insert(new Random().Next(s.Length + 1), Convert.ToString(text));
        }
        public static T[] GetColumn<T>(this T[,] array, int columnNumber)
        {
            if (array == null) throw new ArgumentNullException("Array");
            else if (columnNumber > array.GetLength(1)) throw new IndexOutOfRangeException();
            return Enumerable.Range(0, array.GetLength(0)).Select(x => array[x, columnNumber]).ToArray();
        }
        public static T[] GetRow<T>(this T[,] array, int rowNumber)
        {
            if (rowNumber > array.GetLength(1)) throw new IndexOutOfRangeException();
            else if (array == null) throw new ArgumentNullException("Array");
            return Enumerable.Range(0, array.GetLength(1)).Select(y => array[rowNumber, y]).ToArray();
        }
        public static Type IsWhat<T>(this T anyThing)
        {
            string s = anyThing.ToString();
            if (s.ToLower() == "true" || s.ToLower() == "false") return typeof(bool);

            try
            {
                BigInteger a = BigInteger.Parse(s);
                if (sbyte.MinValue <= a && a <= sbyte.MaxValue) return typeof(sbyte);
                else if (byte.MinValue <= a && a <= byte.MaxValue) return typeof(byte);
                else if (short.MinValue <= a && a <= short.MaxValue) return typeof(short);
                else if (ushort.MinValue <= a && a <= ushort.MaxValue) return typeof(ushort);
                else if (int.MinValue <= a && a <= int.MaxValue) return typeof(int);
                else if (uint.MinValue <= a && a <= uint.MaxValue) return typeof(uint);
                else if (long.MinValue <= a && a <= long.MaxValue) return typeof(long);
                else if (ulong.MinValue <= a && a <= ulong.MaxValue) return typeof(ulong);
                else return typeof(BigInteger);
            }
            catch (Exception)
            {
                try
                {
                    try
                    {
                        try
                        {
                            try
                            {
                                float.Parse(s);
                                return typeof(float);
                            }
                            catch (Exception)
                            {
                                double.Parse(s);
                                return typeof(double);
                            }
                        }
                        catch (Exception)
                        {
                            decimal.Parse(s);
                            return typeof(decimal);
                        }
                    }
                    catch (Exception)
                    {
                        char.Parse(s);
                        return typeof(char);
                    }
                }
                catch (Exception)
                {
                    return typeof(string);
                }
            }
        }
        public static T Abs<T>(this T a)
        {
            if (a.ToString().Contains('-'))
            {
                if (typeof(T) == typeof(BigInteger)) return (T)(object)BigInteger.Parse(a.ToString().Substring(1));
                return (T)Convert.ChangeType(a.ToString().Substring(1), typeof(T));
            }
            else return a;
        }
        public static T GetIntegerPart<T>(this T number)
        {
            string s = number.ToString() ?? "";
            if (s.Contains('.')) return (T)Convert.ChangeType(s.Remove(s.IndexOf('.')), typeof(T));
            return (T)Convert.ChangeType(s, typeof(T)); ;
        }
        public static T GetDecimalPart<T>(this T number)
        {
            string s = number.ToString() ?? "";
            if (s.Contains('.'))
            {
                s = '0' + s.Substring(s.IndexOf('.'));
                if (s.Contains('-')) return (T)Convert.ChangeType('-' + s, typeof(T));
                return (T)Convert.ChangeType(s, typeof(T)); ;
            }
            return (T)Convert.ChangeType(0, typeof(T));
        }

      
        /// <returns>اگه همه ی خط های تکس باکس وایت اسپس باشن ترو میده
        /// در غیر این صورت فالس میده</returns>
        public static bool IsNullOrEmpty(this TextBox textBox)
        {
            if (textBox == null ||
                textBox.Lines.All(x => x.All(y => char.IsWhiteSpace(y)))) return true;

            else return false;
        }
    }
}
