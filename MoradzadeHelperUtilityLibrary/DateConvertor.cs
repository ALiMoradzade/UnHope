using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MoradzadeHelperUtilityLibrary
{
    public class DateConvertor
    {
        private static ushort[] YearsDay = new ushort[3] { 365, 365, 354 };
        public static byte[,] MonthsDay = new byte[3, 12] { { 31, 31, 31, 31, 31, 31, 30, 30, 30, 30, 30, 0 }, { 31, 0, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 }, { 30, 29, 30, 29, 30, 29, 30, 29, 30, 29, 30, 0 } };
        public static string[,] MonthsName = new string[3, 12] { { "فروردین", "اردیبهشت", "خرداد", "تیر", "مرداد", "شهریور", "مهر", "آبان", "آذر", "دی", "بهمن", "اسفند" }, { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" }, { "محرم", "صفر", "ربیع‌الاول", "ربیع‌الثانی", "جمادی‌الاول", "جمادی‌الثانی", "رجب", "شعبان", "رمضان", "شوال", "ذیقعده", "ذیحجه" } };
        public static byte[,] LeapMonthIndexDay = new byte[3, 2] { { 11, 30 }, { 1, 29 }, { 11, 30 } };
        private static int[,] Difference = new int[3, 3] { { 0, 226895, -118 }, { -226895, 0, -227013 }, { 118, 227013, 0 } };
        private static ulong year;
        private static long day;
        private static byte month;
        public static ulong ShowYear() { return year; }
        public static byte ShowMonth() { return month; }
        public static long ShowDay() { return day; }
        public static string WeekDayFinder(sbyte DateType = -1, ulong Year = 0, byte Month = 0, long Day = 0)
        {
            string[] WeekDay = new string[7] { "Saturday", "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday" };

            DefaultValues(ref DateType, ref Year, ref Month, ref Day);

            ushort a = 0;
            for (byte i = 1; i <= Month - 1; i++)
            {
                a += MonthsDay[DateType, i - 1];
            }
            a += (ushort)(LeapYearCount(DateType, Year) % 7 + Day % 7 + 7 - 1);

            if (DateType == 0) a += (ushort)((Year - 1) % 7);
            else if (DateType == 1) a += (ushort)((Year - 1) % 7);
            else if (DateType == 2) a += (ushort)(4 * ((Year - 1) % 7));
            if (DateType == 0) a += 6;
            else if (DateType == 1) a += 2;
            else if (DateType == 2) a += 5;

            return WeekDay[a % 7];
        }

        public static BigInteger LeapYearCount(sbyte DateType = -1, ulong Year = 0)
        {
            if (Year != 1)
            {
                DefaultValues(ref DateType, ref Year);
                --Year;
                BigInteger b = 0;
                if (DateType == 0)
                {
                    byte[] a = new byte[8] { 1, 5, 9, 13, 17, 22, 26, 30 };
                    foreach (byte i in a)
                    {
                        b += (BigInteger)Math.Floor((Year - (double)i) / 33) - (BigInteger)Math.Ceiling(-(double)i / 33) + 1;
                    }
                    --b;
                }
                else if (DateType == 1)
                {
                    b = (Year / 400) + (Year / 4) - (Year / 100);
                }
                else if (DateType == 2)
                {
                    b = 0;
                    byte[] a = new byte[11] { 2, 5, 7, 10, 13, 16, 18, 21, 24, 26, 29 };
                    foreach (BigInteger i in a)
                    {
                        b += (BigInteger)Math.Floor((Year - (double)i) / 30) - (BigInteger)Math.Ceiling(-(double)i / 30) + 1;
                    }
                }
                return b;
            }
            else return 0;
        }
        public static BigInteger LeapYearCount(sbyte DateType, ulong firstYear, ulong secondYear)
        {
            BigInteger b = LeapYearCount(DateType, firstYear) - LeapYearCount(DateType, secondYear);
            return (b > 0) ? b : -b;
        }

        public static bool LeapYearQuery(sbyte DateType = -1, ulong Year = 0)
        {
            if (Year != 1)
            {
                DefaultValues(ref DateType, ref Year);
                if (DateType == 0)
                {
                    return new[] { 1, 5, 9, 13, 17, 22, 26, 30 }.Contains((byte)(Year % 33)) ? true : false;
                }
                else if (DateType == 1)
                {
                    return (Year % 400 == 0 || (Year % 100 != 0 && Year % 4 == 0)) ? true : false;
                }
                else if (DateType == 2)
                {
                    return new[] { 2, 5, 7, 10, 13, 16, 18, 21, 24, 26, 29 }.Contains((byte)(Year % 30)) ? true : false;
                }
            }
            return false;
        }

        public static BigInteger ConvertDatetoDay(sbyte DateType = -1, ulong Year = 0, byte Month = 0, long Day = 0)
        {
            DefaultValues(ref DateType, ref Year, ref Month, ref Day);

            if (LeapYearQuery(DateType, Year)) MonthsDay[DateType, LeapMonthIndexDay[DateType, 0]] = LeapMonthIndexDay[DateType, 1];
            else MonthsDay[DateType, LeapMonthIndexDay[DateType, 0]] = (byte)(LeapMonthIndexDay[DateType, 1] - 1);

            ushort a = 0;
            for (sbyte i = 1; i <= Month - 1; i++)
            {
                a += MonthsDay[DateType, i - 1];
            }

            return (((BigInteger)Year - 1) * YearsDay[DateType]) + a + Day + LeapYearCount(DateType, Year);
        }
        public static BigInteger ConvertDatetoDay(sbyte DateType, ulong firstYear, byte firstMonth, byte firstDay, ulong secondYear, byte secondMonth, byte secondDay)
        {
            return ConvertDatetoDay(DateType, firstYear, firstMonth, firstDay) - ConvertDatetoDay(DateType, secondYear, secondMonth, secondDay);
        }

        public static string ConvertDate(sbyte ConvertDateTo, sbyte DateType = -1, ulong Year = 0, byte Month = 0, long Day = 0)
        {
            if (IsInRange(ConvertDateTo, DateType, Year, Month, Day))
            {
                DefaultValues(ref DateType, ref Year, ref Month, ref Day);

                BigInteger b = ConvertDatetoDay(DateType, Year, Month, Day), c;

                if (b < 0) return b.ToString();

                b += Difference[DateType, ConvertDateTo];

                Year = (ulong)(b / YearsDay[ConvertDateTo]) + 1;
            Again:
                c = b - (((Year - 1) * YearsDay[ConvertDateTo]) + LeapYearCount(ConvertDateTo, Year));
                if (c <= 0)
                {
                    ulong d = (ulong)(-c / YearsDay[ConvertDateTo]) + 1;
                    Year -= d;
                    goto Again;
                }
                else if (c > YearsDay[ConvertDateTo] + 1)
                {
                    ulong d = (ulong)(c / YearsDay[ConvertDateTo]) + 1;
                    Year += d;
                    goto Again;
                }
                else if ((c == YearsDay[ConvertDateTo] + 1) && !(c != YearsDay[ConvertDateTo] + 1 || LeapYearQuery(ConvertDateTo, Year)))
                {
                    ++Year;
                    goto Again;
                }

                if (LeapYearQuery(ConvertDateTo, Year)) MonthsDay[ConvertDateTo, LeapMonthIndexDay[ConvertDateTo, 0]] = LeapMonthIndexDay[ConvertDateTo, 1];
                else MonthsDay[ConvertDateTo, LeapMonthIndexDay[ConvertDateTo, 0]] = (byte)(LeapMonthIndexDay[ConvertDateTo, 1] - 1);

                Day = (long)c;
                c = 0;
                for (byte i = 1; i <= 12; i++)
                {
                    if (Day <= MonthsDay[ConvertDateTo, i - 1])
                    {
                        c = i;
                        break;
                    }
                    c += MonthsDay[ConvertDateTo, i - 1];
                    Day -= MonthsDay[ConvertDateTo, i - 1];
                }
                year = Year;
                month = (byte)c;
                day = Day;
                return $"{Year:00}/{c:00}/{Day:00}";
            }
            else return "Length Error!";
        }
        private static bool IsInRange(sbyte ConvertDateTo, sbyte DateType, ulong Year, byte Month, long Day)
        {
            if (!((ConvertDateTo == 2 && DateType == 0 && Year == 1 && (Month < 4 || Month == 4 && Day < 30)) || Year != 0 && ((ConvertDateTo == 0 && DateType == 1 && (Year < 622 || (Year == 622 && (Month < 3 || Month == 3 && Day < 22)))) || (ConvertDateTo == 2 && DateType == 1 && (Year < 622 || (Year == 622 && (Month < 7 || Month == 7 && Day < 18))))))) return true;
            else return false;
        }
        private static void DefaultValues(ref sbyte DateType, ref ulong Year, ref byte Month, ref long Day)
        {
            var d = DateTime.Now;
            if (Year == 0) Year = ushort.Parse(d.ToString("yyyy"));
            if (Month == 0) Month = byte.Parse(d.ToString("MM"));
            if (Day == 0) Day = byte.Parse(d.ToString("dd"));
            if (DateType == -1)
            {
                if (Year > 2021) DateType = 1;
                else if (Year > 1443) DateType = 2;
                else if (Year > 1400) DateType = 0;
            }
        }
        private static void DefaultValues(ref sbyte DateType, ref ulong Year)
        {
            var d = DateTime.Now;
            if (Year == 0) Year = ushort.Parse(d.ToString("yyyy"));
            if (DateType == -1)
            {
                if (Year > 2021) DateType = 1;
                else if (Year > 1443) DateType = 2;
                else if (Year > 1400) DateType = 0;
            }
        }
    }
}
