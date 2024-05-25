using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MoradzadeHelperUtilityLibrary
{
    public struct MultiBaseNumber
    {
        bool isNegative;
        string encodedNumber;
        BigInteger intPart;
        decimal decimalPart;
        readonly string currentBase;
        readonly static string defaultBase = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        public MultiBaseNumber(dynamic encodedNum, dynamic @base)
        {
            string code = encodedNum.ToString(), tmp;

            if (@base.GetType() == typeof(string))
            {
                if (@base.ToString().Contains("-")) throw new ArgumentException("Base can't have dash(-) character!");
                currentBase = @base.ToString();
            }
            else if (@base.GetType() == typeof(int))
            {
                if (1 < (int)@base && (int)@base <= 36)
                {
                    currentBase = defaultBase.Substring(0, (int)@base);
                    code = code.ToUpper();
                }
                else if ((int)@base == 64) currentBase = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/";
                else throw new ArgumentOutOfRangeException("Base is between 2 and 36 and 64 ==> [2,36] ⋀ 64");
            }
            else throw new ArgumentException("Base: Wrong Input!");

            if (string.IsNullOrEmpty(code)) throw new ArgumentNullException("encodedNum can't be empty or null!");
            else
            {
                if (code.Contains('-')) throw new ArgumentOutOfRangeException("encodedNum can't be negative!");

                tmp = currentBase;
                if (!code.Replace(".", "").All(x => tmp.Contains(x))) throw new ArgumentOutOfRangeException("All encodedNum's characters must be in base!");

                code = FastCode.OmitExtraZero(code, currentBase);
                if (code == "0") throw new ArgumentOutOfRangeException("encodedNum can't be zero!");
            }

            encodedNumber = code;
            code = DecodeToBase10(code, currentBase);
            intPart = BigInteger.Parse(code.GetIntegerPart());
            decimalPart = decimal.Parse(code.GetDecimalPart());
            isNegative = false;
        }
        public MultiBaseNumber(MultiBaseNumber mBN, dynamic @base)
        {
            if (@base.GetType() == typeof(string))
            {
                if (@base.ToString().Contains("-")) throw new ArgumentException("Base can't have dash(-) character!");
                currentBase = @base.ToString();
            }
            else if (@base.GetType() == typeof(int))
            {
                if (1 < (int)@base && (int)@base <= 36) currentBase = defaultBase.Substring(0, (int)@base);
                else if ((int)@base == 64) currentBase = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/";
                else throw new ArgumentOutOfRangeException("Base is between 2 and 36 and 64 ==> [2,36] ⋀ 64");
            }
            else throw new ArgumentException("Base: Wrong Input!");

            string decode = DecodeToBase10(mBN.encodedNumber, mBN.currentBase);
            intPart = BigInteger.Parse(decode.GetIntegerPart());
            decimalPart = decimal.Parse(decode.GetDecimalPart());
            encodedNumber = EncodeToBase(intPart, decimalPart, currentBase);
            isNegative = mBN.isNegative;
        }

        public bool IsNegative => isNegative;
        public string EncodedNumber => encodedNumber;
        public string DecodedNumber
        {
            get
            {
                string s = decimalPart.ToString();
                if (s.Contains('.')) s = s.Substring(s.IndexOf('.'));
                return intPart + (s == "0" ? "" : s);
            }
        }
        public BigInteger IntegerPart => intPart;
        public decimal DecimalPart => decimalPart;

        static string EncodeToBase(BigInteger integerPart, decimal decimalPart, string currentBase)
        {
            string tmp = "";
            while (integerPart > 0)
            {
                tmp += currentBase[(int)(integerPart % currentBase.Length)];
                integerPart /= currentBase.Length;
            }
            tmp = string.Concat(tmp.Reverse());
            if (decimalPart != 0)
            {
                tmp += '.';
                while (decimalPart > 0)
                {
                    tmp += currentBase[(int)(decimalPart * currentBase.Length)];
                    decimalPart %= (decimal)Math.Pow(currentBase.Length, -1);
                    decimalPart *= currentBase.Length;
                }
            }
            return tmp;
        }
        static string DecodeToBase10(string encodedNumber, string currentBase)
        {
            BigInteger a = 0;
            decimal b = 0;
            int power = (encodedNumber.Contains('.') ? encodedNumber.Remove(encodedNumber.IndexOf('.')).Length : encodedNumber.Length) - 1;
            encodedNumber = encodedNumber.Replace(".", "");
            foreach (char c in encodedNumber)
            {
                if (power >= 0) a += currentBase.IndexOf(c) * BigInteger.Pow(currentBase.Length, power);
                else b += currentBase.IndexOf(c) * (decimal)Math.Pow(currentBase.Length, power);
                power--;
            }
            encodedNumber = a + b.ToString().Substring(1);
            return FastCode.OmitExtraZero(encodedNumber, "0123456789");
        }
        public bool IsBiggerThan(MultiBaseNumber a)
        {
            if (!isNegative && a.isNegative) return true;
            else if (isNegative && !a.isNegative) return false;

            if (intPart > a.intPart) return true;
            else if (intPart < a.intPart) return false;

            if (decimalPart > a.decimalPart) return true;
            return false;
        }
        public bool IsEqualTo(MultiBaseNumber b)
        {
            if (!IsBiggerThan(b) && !b.IsBiggerThan(this)) return true;
            return false;
        }
        MultiBaseNumber Abs()
        {
            MultiBaseNumber tmp = this;
            tmp.isNegative = false;
            tmp.encodedNumber = tmp.encodedNumber.Replace("-", "");
            tmp.intPart = BigInteger.Abs(tmp.intPart);
            tmp.decimalPart = Math.Abs(tmp.decimalPart);
            return tmp;
        }

        /// <summary>r's Complement</summary>
        public MultiBaseNumber RadixComplement() => DiminishedRadixComplement() + 1;
        /// <summary>(r-1)'s Complement</summary>
        public MultiBaseNumber DiminishedRadixComplement()
        {
            int digit = encodedNumber.Length;
            if (encodedNumber.Contains('.')) digit--;
            MultiBaseNumber tmp = new MultiBaseNumber(new string(currentBase.Last(), digit), currentBase);
            return tmp - this;
        }

        public override string ToString()
        {
            if (encodedNumber.Last() == '.') return encodedNumber.Remove(encodedNumber.Length - 1);
            return encodedNumber;
        }

        #region Overload Operators
        public static MultiBaseNumber operator +(MultiBaseNumber a) => a;
        public static MultiBaseNumber operator +(MultiBaseNumber a, dynamic b)
        {
            if (b.GetType() == typeof(MultiBaseNumber))
            {
                MultiBaseNumber tmp = new MultiBaseNumber(b, b.currentBase);
                tmp = new MultiBaseNumber(tmp, a.currentBase);
                return a + tmp;
            }
            else if (FastCode.IsNumber(b))
            {
                MultiBaseNumber tmp = new MultiBaseNumber(b, 10);
                tmp = new MultiBaseNumber(tmp, a.currentBase);
                return a + tmp;
            }
            throw new InvalidOperationException($"Cannot implicitly convert type '{b.GetType()}' to 'MultiBaseNumber'.");
        }
        public static MultiBaseNumber operator +(decimal a, MultiBaseNumber b) => b + a;
        public static MultiBaseNumber operator +(MultiBaseNumber a, MultiBaseNumber b)
        {
            if (a.currentBase != b.currentBase) throw new ArgumentException("Base of two operands must be the same!");

            if (a.isNegative && (b.isNegative || a.Abs().IsBiggerThan(b.Abs()))) return -(-a + -b);
            else if (!a.Abs().IsBiggerThan(b.Abs()) && (a.isNegative || b.isNegative)) return b + a;

            a.decimalPart += b.decimalPart;
            if (a.decimalPart < 0)
            {
                a.decimalPart++;
                a.intPart--;
            }
            else if (a.decimalPart >= 1)
            {
                a.decimalPart--;
                a.intPart++;
            }
            a.intPart += b.intPart;
            a.encodedNumber = EncodeToBase(a.intPart, a.decimalPart, a.currentBase);
            return a;
        }
        public static MultiBaseNumber operator ++(MultiBaseNumber a) => a + 1;

        public static MultiBaseNumber operator -(MultiBaseNumber a)
        {
            a.intPart = -a.intPart;
            a.decimalPart = -a.decimalPart;
            a.encodedNumber = a.encodedNumber.Contains('-') ? a.encodedNumber.Replace("-", "") : a.encodedNumber.Insert(0, "-");
            a.isNegative = !a.isNegative;
            return a;
        }
        public static MultiBaseNumber operator -(MultiBaseNumber a, dynamic b)
        {
            if (b.GetType() == typeof(MultiBaseNumber))
            {
                MultiBaseNumber tmp = new MultiBaseNumber(b, b.currentBase);
                tmp = new MultiBaseNumber(tmp, a.currentBase);
                return a - tmp;
            }
            else if (FastCode.IsNumber(b))
            {
                MultiBaseNumber tmp = new MultiBaseNumber(b, 10);
                tmp = new MultiBaseNumber(tmp, a.currentBase);
                return a - tmp;
            }
            throw new InvalidOperationException($"Cannot implicitly convert type '{b.GetType()}' to 'MultiBaseNumber'.");
        }
        public static MultiBaseNumber operator -(decimal a, MultiBaseNumber b) => b - a;
        public static MultiBaseNumber operator -(MultiBaseNumber a, MultiBaseNumber b)
        {
            if (a.currentBase != b.currentBase) throw new ArgumentException("Base of two operands must be the same!");

            if (a.isNegative) return -(-a + b);
            else if (b.isNegative && !a.Abs().IsBiggerThan(b.Abs())) return b - a;
            return a + -b;
        }
        public static MultiBaseNumber operator --(MultiBaseNumber a) => a - 1;
        #endregion
    }
}
