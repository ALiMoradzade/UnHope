using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoradzadeHelperUtilityLibrary
{
    public struct TimeCalculator
    {
        public readonly static int[] timeInSec = new int[7] { 365 * 24 * 3600, 30 * 24 * 3600, 7 * 24 * 3600, 24 * 3600, 3600, 60, 1 };
        int year, month, week, day, hour, minute;
        double second;
        bool isNegative;

        public TimeCalculator(decimal seconds)
        {
            if (seconds < 0) throw new ArgumentException("Second can't be negative!");

            year = (int)(seconds / timeInSec[0]);

            seconds %= timeInSec[0];
            month = (int)(seconds / timeInSec[1]);

            seconds %= timeInSec[1];
            week = (int)(seconds / timeInSec[2]);

            seconds %= timeInSec[2];
            day = (int)(seconds / timeInSec[3]);

            seconds %= timeInSec[3];
            hour = (int)(seconds / timeInSec[4]);

            seconds %= timeInSec[4];
            minute = (int)(seconds / timeInSec[5]);

            seconds %= timeInSec[5];
            second = (double)seconds;

            isNegative = false;
        }
        public TimeCalculator(uint year = 0, uint month = 0, uint week = 0, uint day = 0, uint hour = 0, uint minute = 0, double second = 0)
        {
            checked
            {
                this.year = (int)year;
                this.month = (int)month;
                this.week = (int)week;
                this.day = (int)day;
                this.hour = (int)hour;
                this.minute = (int)minute;
                this.second = second;
                isNegative = false;
            }

            CheckSecond(ref this);
            CheckMinute(ref this);
            CheckHour(ref this);
            CheckDay(ref this);
            CheckWeek(ref this);
            CheckMonth(ref this);
        }
        public TimeCalculator(TimeCalculator tC)
        {
            year = tC.year;
            month = tC.month;
            week = tC.week;
            day = tC.day;
            hour = tC.hour;
            minute = tC.minute;
            second = tC.second;
            isNegative = tC.isNegative;
        }

        public int Year => year;
        public int Month => month;
        public int Week => week;
        public int Day => day;
        public int Hour => hour;
        public int Minute => minute;
        public double Second => second;
        public object[] ValuesArray => new object[] { year, month, week, day, hour, minute, second };
        public bool IsNegative => isNegative;

        public decimal GetYears() => GetSeconds() / timeInSec[0];
        public decimal GetMonths() => GetSeconds() / timeInSec[1];
        public decimal GetWeeks() => GetSeconds() / timeInSec[2];
        public decimal GetDays() => GetSeconds() / timeInSec[3];
        public decimal GetHours() => GetSeconds() / timeInSec[4];
        public decimal GetMinutes() => GetSeconds() / timeInSec[5];
        public decimal GetSeconds() => (decimal)year * timeInSec[0] + (decimal)month * timeInSec[1] + (decimal)week * timeInSec[2] + (decimal)day * timeInSec[3] + (decimal)hour * timeInSec[4] + (decimal)minute * timeInSec[5] + (decimal)second;

        public override string ToString()
        {
            string s = "";

            if (year != 0)
            {
                s += year + " Year";
                if (year > 1) s += 's';
                s += ' ';
            }
            if (month != 0)
            {
                s += month + " Month";
                if (month > 1) s += 's';
                s += ' ';
            }
            if (week != 0)
            {
                s += week + " Week";
                if (week > 1) s += 's';
                s += ' ';
            }
            if (day != 0)
            {
                s += day + " Day";
                if (day > 1) s += 's';
                s += ' ';
            }
            if (hour != 0)
            {
                s += hour + " Hour";
                if (hour > 1) s += 's';
                s += ' ';
            }
            if (minute != 0)
            {
                s += minute + " Minute";
                if (minute > 1) s += 's';
                s += ' ';
            }
            if (second != 0)
            {
                s += second + " Second";
                if (second > 1) s += 's';
                s += ' ';
            }
            return s.TrimEnd();
        }

        bool IsBiggerThan(TimeCalculator a)
        {
            if (year > a.year) return true;
            else if (year < a.year) return false;

            if (month > a.month) return true;
            else if (month < a.month) return false;

            if (week > a.week) return true;
            else if (week < a.week) return false;

            if (day > a.day) return true;
            else if (day < a.day) return false;

            if (hour > a.hour) return true;
            else if (hour < a.hour) return false;

            if (minute > a.minute) return true;
            else if (minute < a.minute) return false;

            if (second > a.second) return true;
            return false;
        }
        public bool IsEqualTo(TimeCalculator a)
        {
            if (year == a.year && month == a.month && week == a.week && hour == a.hour && minute == a.minute && second == a.second) return true;
            return false;
        }

        #region Overload Operators
        public static TimeCalculator operator +(TimeCalculator a) => a;
        public static TimeCalculator operator +(TimeCalculator a, TimeCalculator b)
        {
            a.second += b.second;
            CheckSecond(ref a);

            a.minute += b.minute;
            CheckMinute(ref a);

            a.hour += b.hour;
            CheckHour(ref a);

            a.day += b.day;
            CheckDay(ref a);

            a.week += b.week;
            CheckWeek(ref a);

            a.month += b.month;
            CheckMonth(ref a);

            a.year += b.year;
            return a;
        }

        public static TimeCalculator operator -(TimeCalculator a)
        {
            a.isNegative = true;
            a.second = -a.second;
            a.minute = -a.minute;
            a.hour = -a.hour;
            a.day = -a.day;
            a.week = -a.week;
            a.month = -a.month;
            a.year = -a.year;
            return a;
        }
        public static TimeCalculator operator -(TimeCalculator a, TimeCalculator b)
        {
            bool isChnaged = false;
            if (b.IsBiggerThan(a))
            {
                FastCode.Swap(ref a, ref b);
                isChnaged = true;
                a.isNegative = true;
            }
            a = a + -b;
            return isChnaged ? -a : a;
        }

        #region Ops
        static void CheckSecond(ref TimeCalculator tC)
        {
            if (tC.second > 59)
            {
                int n = (int)(tC.second / 60);
                tC.second %= 60;
                tC.minute += n;
            }
            else if (tC.second < 0)
            {
                int n = (int)Math.Ceiling(-tC.second / 60);
                tC.second += n * 60;
                tC.minute -= n;
            }
        }
       
        static void CheckMinute(ref TimeCalculator tC)
        {
            if (tC.minute > 59)
            {
                int n = tC.minute / 60;
                tC.minute %= 60;
                tC.hour += n;
            }
            else if (tC.minute < 0)
            {
                int n = (int)Math.Ceiling(-tC.minute / 60d);
                tC.minute += n * 60;
                tC.hour -= n;
            }
        }
       
        static void CheckHour(ref TimeCalculator tC)
        {
            if (tC.hour > 23)
            {
                int tmp = tC.hour / 24;
                tC.hour %= 24;
                tC.day += tmp;
            }
            else if (tC.hour < 0)
            {
                int n = (int)Math.Ceiling(-tC.hour / 24d);
                tC.hour += n * 24;
                tC.day -= n;
            }
        }

        static void CheckDay(ref TimeCalculator tC)
        {
            if (tC.day > 6)
            {
                int n = tC.day / 7;
                tC.day %= 7;
                tC.week += n;
            }
            else if (tC.day < 0)
            {
                int n = (int)Math.Ceiling(-tC.day / 7d);
                tC.day += n * 7;
                tC.week--;
            }
        }
     
        static void CheckWeek(ref TimeCalculator tC)
        {
            if (tC.week > 3)
            {
                int tmp = 7 * tC.week + tC.day;
                int n = tmp / 30;
                tC.day = tmp % 30;
                tC.week = 0;
                CheckDay(ref tC);
                tC.month += n;
            }
            else if (tC.week < 0)
            {
                int days = 7 * -tC.week;
                int n = (int)Math.Ceiling(days / 30d);
                tC.day += n * 30 - days;
                tC.week = 0;
                CheckDay(ref tC);
                tC.month -= n;
            }
        }
   
        static void CheckMonth(ref TimeCalculator tC)
        {
            if (tC.month > 11)
            {
                int tmp = 30 * tC.month + tC.day;
                int n = tmp / 365;
                tC.day = tmp % 365;
                tC.month = 0;
                CheckDay(ref tC);
                CheckWeek(ref tC);
                tC.year += n;
            }
            else if (tC.month < 0)
            {
                int days = 12 * -tC.month;
                int n = (int)Math.Ceiling(days / 365d);
                tC.day += n * 365 - days;
                tC.month = 0;
                CheckDay(ref tC);
                CheckWeek(ref tC);
                tC.year -= n;
            }
        }
        #endregion

        #endregion
    }
}
