using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoradzadeHelperUtilityLibrary
{
    public struct ComplexNumber
    {
        double real;
        double image;

        public ComplexNumber(double real = 0, double imaginary = 0)
        {
            this.real = real;
            image = imaginary;
        }
        public ComplexNumber(ComplexNumber cN)
        {
            real = cN.real;
            image = cN.image;
        }

        public double Real { get => real; set => real = value; }
        public double Imaginary { get => image; set => image = value; }

        public ComplexNumber Conjugate() => new ComplexNumber(real, -image);
        public double Absolute() => Math.Sqrt(Math.Pow(real, 2) + Math.Pow(image, 2));
        public ComplexNumber[] SquareRoot()
        {
            double abs = Absolute(), r = Math.Sqrt((abs + real) / 2), i = Math.Sqrt((abs - real) / 2);
            return new ComplexNumber[2] { new ComplexNumber(r, i), -new ComplexNumber(r, i) };
        }
        public override string ToString()
        {
            string s = "";
            s += real != 0 ? real.ToString() : "";
            if (image > 0) s += '+';
            s += image != 0 ? image.ToString() + 'i' : "";
            return s != "" ? s : "0";
        }

        #region Overload Operators
        public static ComplexNumber operator +(ComplexNumber a) => a;
        public static ComplexNumber operator +(ComplexNumber a, double b)
        {
            a.real += b;
            return a;
        }
        public static ComplexNumber operator +(double a, ComplexNumber b) => b + a;
        public static ComplexNumber operator +(ComplexNumber a, ComplexNumber b)
        {
            a.real += b.real;
            a.image += b.image;
            return a;
        }

        public static ComplexNumber operator -(ComplexNumber a)
        {
            a.real = -a.real;
            a.image = -a.image;
            return a;
        }
        public static ComplexNumber operator -(ComplexNumber a, double b) => a + -b;
        public static ComplexNumber operator -(double a, ComplexNumber b) => b + -a;
        public static ComplexNumber operator -(ComplexNumber a, ComplexNumber b) => a + -b;

        public static ComplexNumber operator *(ComplexNumber a, double b)
        {
            a.real *= b;
            a.image *= b;
            return a;
        }
        public static ComplexNumber operator *(double a, ComplexNumber b) => b * a;
        public static ComplexNumber operator *(ComplexNumber a, ComplexNumber b)
        {
            ComplexNumber tmp = new ComplexNumber();
            tmp.real = a.real * b.real - a.image * b.image;
            tmp.image = a.real * b.image + a.image * b.real;
            return tmp;
        }

        public static ComplexNumber operator /(ComplexNumber a, double b) => a * (1 / b);
        public static ComplexNumber operator /(double a, ComplexNumber b) => (b ^ -1) * a;
        public static ComplexNumber operator /(ComplexNumber a, ComplexNumber b) => a * (b ^ -1);

        public static ComplexNumber operator ^(ComplexNumber a, short power)
        {
            if (power == 0) return new ComplexNumber();
            else if (power == 1) return a;
            else if (power > 1)
            {
                ComplexNumber b = new ComplexNumber(a * a), tmp = b;
                ushort odd = (ushort)(power % 2), even = (ushort)(power / 2);
                if (even > 1)
                {
                    for (ushort i = 1; i < even; i++)
                    {
                        tmp *= b;
                    }
                }
                if (odd == 1) tmp *= a;
                return tmp;
            }
            else
            {
                a = a.Conjugate() / Math.Pow(a.Absolute(), 2);
                return a ^ (short)-power;
            }
        }
        #endregion
    }
}