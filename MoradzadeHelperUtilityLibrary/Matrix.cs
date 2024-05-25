using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoradzadeHelperUtilityLibrary
{
    public struct Matrix
    {
        double[,] matrice;

        public Matrix(int row = 0, int column = 0)
        {
            matrice = new double[row, column];
        }
        public Matrix(double[,] matrice)
        {
            this.matrice = matrice ?? throw new ArgumentNullException("Matrice can't be null!");
        }
        public Matrix(Matrix m)
        {
            matrice = m.matrice ?? throw new ArgumentNullException("Matrice can't be null!");
        }

        public double[,] Matrice
        {
            get => matrice;
            set => matrice = value ?? throw new ArgumentNullException("Matrice can't be null!");
        }

        bool IsSquare()
        {
            if (matrice == null) throw new ArgumentNullException("Matrice can't be null!");
            else if (matrice.GetLength(0) == matrice.GetLength(1)) return true;
            return false;
        }
        static bool CanAdditionAndSubtractionWith(Matrix a, Matrix b)
        {
            if (a.matrice == null && b.matrice == null) throw new ArgumentNullException("Matrices can't be null!");
            else if (a.matrice.GetLength(0) == b.matrice.GetLength(0) && a.matrice.GetLength(1) == b.matrice.GetLength(1)) return true;
            return false;
        }
        static bool CanMultiplicationWith(Matrix a, Matrix b)
        {
            if (a.matrice == null && b.matrice == null) throw new ArgumentNullException("Matrices can't be null!");
            else if (a.matrice.GetLength(0) == b.matrice.GetLength(1) && a.matrice.GetLength(1) == b.matrice.GetLength(0)) return true;
            return false;
        }

        /// <summary>دترمینان ماتریس را نشان میدهد</summary>
        public double Determinant()
        {
            if (matrice == null) throw new ArgumentNullException("Matrice can't be null!");
            else if (IsSquare()) return Determinant(matrice);
            throw new ArrayTypeMismatchException("Matrice is not square!");
        }
        static double Determinant(double[,] a)
        {
            if (a.GetLength(0) == 1) return a[0, 0];
            else if (a.GetLength(0) == 2) return a[0, 0] * a[1, 1] - a[0, 1] * a[1, 0];
            double det = 0;
            for (int i = 0; i < a.GetLength(0); i++)
            {
                det += a[0, i] * Cofactor(a, 0, i);
            }
            return det;
        }
        static double Cofactor(double[,] a, int elementRow, int elementColumn)
        {
            int n = a.GetLength(0);
            List<double> l = new List<double>();
            for (int i = 0, k = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++, k++)
                {
                    if (i != elementRow && j != elementColumn) l.Add(a[i, j]);
                }
            }
            --n;
            double[,] b = new double[n, n];

            for (int i = 0, k = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++, k++)
                {
                    b[i, j] = l[k];
                }
            }
            if ((elementRow + elementColumn) % 2 == 1) return -Determinant(b);
            return Determinant(b);
        }

        /// <summary>ترانهاده ی ماتریس را نشان میدهد</summary>
        public Matrix Transpose()
        {
            if (matrice == null) throw new ArgumentNullException("Matrice can't be null!");

            List<double> l = new List<double>();
            for (int i = 0; i < matrice.GetLength(1); i++)
            {
                l.AddRange(matrice.GetColumn(i));
            }

            double[,] a = new double[matrice.GetLength(1), matrice.GetLength(0)];

            for (int i = 0, k = 0; i < matrice.GetLength(0); i++)
            {
                for (int j = 0; j < matrice.GetLength(1); j++, k++)
                {
                    a[i, j] = l[k];
                }
            }
            return new Matrix(a);
        }

        /// <summary>ماتریس الحاقی را نشان میدهد</summary>
        public Matrix Adjoint()
        {
            if (matrice == null) throw new ArgumentNullException("Matrice can't be null!");
            else if (IsSquare())
            {
                double[,] a = new double[matrice.GetLength(0), matrice.GetLength(1)];

                for (int i = 0; i < matrice.GetLength(0); i++)
                {
                    for (int j = 0; j < matrice.GetLength(1); j++)
                    {
                        a[i, j] = Cofactor(matrice, i, j);
                    }
                }
                return new Matrix(a).Transpose();
            }
            throw new ArrayTypeMismatchException("Matrice is not square!");
        }

        /// <summary>همه ی درایه های ماتریس را یک مقدار قرار میدهد</summary>
        public Matrix SetAllElements(double b)
        {
            if (matrice == null) throw new ArgumentNullException("Matrice can't be null!");

            double[,] a = new double[matrice.GetLength(0), matrice.GetLength(1)];

            for (int i = 0; i < matrice.GetLength(0); i++)
            {
                for (int j = 0; j < matrice.GetLength(1); j++)
                {
                    a[i, j] = b;
                }
            }
            return new Matrix(a);
        }

        /// <summary>ماتریس صفر</summary>
        public Matrix Zero() => SetAllElements(0);

        /// <summary>ماتریس واحد</summary>
        public Matrix Unit() => SetAllElements(1);

        public override string ToString()
        {
            string s = "";
            for (int i = 0; i < matrice.GetLength(0); i++)
            {
                s += string.Join(" ", matrice.GetRow(i)) + '\n';
            }
            return s;
        }

        #region Overload Operators
        public static Matrix operator +(Matrix a) => a;
        public static Matrix operator +(Matrix a, Matrix b)
        {
            if (CanAdditionAndSubtractionWith(a, b))
            {
                for (int i = 0; i < a.matrice.GetLength(0); i++)
                {
                    for (int j = 0; j < a.matrice.GetLength(1); j++)
                    {
                        a.matrice[i, j] = a.matrice[i, j] + b.matrice[i, j];
                    }
                }
                return a;
            }
            throw new ArrayTypeMismatchException("Can't do addition or subtraction with these two matrix!");
        }

        public static Matrix operator -(Matrix a)
        {
            for (int i = 0; i < a.matrice.GetLength(0); i++)
            {
                for (int j = 0; j < a.matrice.GetLength(1); j++)
                {
                    a.matrice[i, j] = -a.matrice[i, j];
                }
            }
            return a;
        }
        public static Matrix operator -(Matrix a, Matrix b) => a + -b;

        public static Matrix operator *(double a, Matrix b)
        {
            for (int i = 0; i < b.matrice.GetLength(0); i++)
            {
                for (int j = 0; j < b.matrice.GetLength(1); j++)
                {
                    b.matrice[i, j] = a * b.matrice[i, j];
                }
            }
            return b;
        }
        public static Matrix operator *(Matrix a, double b) => b * a;
        public static Matrix operator *(Matrix a, Matrix b)
        {
            if (CanMultiplicationWith(a, b))
            {
                double[,] tmp = new double[a.matrice.GetLength(0), b.matrice.GetLength(1)];
                for (int i = 0; i < a.matrice.GetLength(0); i++)
                {
                    for (int j = 0; j < b.matrice.GetLength(1); j++)
                    {
                        double l = 0;
                        for (int k = 0; k < a.matrice.GetLength(1); k++)
                        {
                            l += a.matrice.GetRow(i)[k] * b.matrice.GetColumn(j)[k];
                        }
                        tmp[i, j] = l;
                    }
                }
                return new Matrix(tmp);
            }
            throw new ArrayTypeMismatchException("Can't do multiplication with these two matrix!");
        }

        public static Matrix operator /(Matrix a, double b) => a * (1 / b);
        public static Matrix operator /(double a, Matrix b) => a * (b ^ -1);
        public static Matrix operator /(Matrix a, Matrix b) => a * (b ^ -1);

        public static Matrix operator ^(Matrix a, short power)
        {
            if (power == 0) return a.Unit();
            else if (power == 1) return a;
            else if (power > 1)
            {
                Matrix b = new Matrix(a * a), tmp = b;
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
                double det = a.Determinant();
                if (det == 0) throw new ArrayTypeMismatchException("Matrice is not invertible");
                a = a.Adjoint() / det;
                return a ^ (short)-power;
            }
        }
        #endregion
    }
}
