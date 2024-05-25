using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoradzadeHelperUtilityLibrary
{
    public class DataStructure
    {
        static string[] operatorPriority = new string[] { ",", "(", ")", "!", "^", "|", "*", "/", "%", "&", "+", "-", "<", ">", "<=", ">=", "!=" };
        public static string InfixToPostfix(string phrase)
        {
            return InfixToPostfix(phrase, operatorPriority);
        }
        public static string InfixToPrefix(string phrase)
        {
            return InfixToPrefix(phrase, operatorPriority);
        }
        public static string PostfixToInfix(string phrase)
        {
            return PostfixToInfix(phrase, operatorPriority);
        }
        public static string PrefixToInfix(string phrase)
        {
            return PrefixToInfix(phrase, operatorPriority);

        }

        public static string InfixToPostfix(string phrase, string[] operatorPriority)
        {
            string[] s = FastCode.ConvertStringToArray(phrase, operatorPriority);
            if (s.Where(x => !operatorPriority.Contains(x)).Count() - s.Where(x => operatorPriority.Contains(x) && x != "(" && x != ")").Count() != 1) throw new FormatException();

            Stack<string> operatorr = new Stack<string>(), operand = new Stack<string>();
            phrase = "";
            foreach (string i in s)
            {
                if (operatorPriority.Contains(i))
                {
                    if (i == "(" || operatorr.Count == 0 || operatorr.First() == "(") operatorr.Push(i);
                    else if (i == ")")
                    {
                        while (operatorr.First() != "(")
                        {
                            phrase += operatorr.Pop();
                        }
                        operatorr.Pop();
                    }
                    else
                    {
                        int a = Array.IndexOf(operatorPriority, operatorr.First()), b = Array.IndexOf(operatorPriority, i);
                        if (a > b) operatorr.Push(i);
                        else if (a <= b)
                        {
                            while (operatorr.Count > 0 && Array.IndexOf(operatorPriority, operatorr.First()) <= b)
                            {
                                phrase += operatorr.Pop();
                            }
                            operatorr.Push(i);
                        }
                        else throw new ArithmeticException();
                    }
                }
                else phrase += i;
            }
            while (operatorr.Count > 0)
            {
                phrase += operatorr.Pop();
            }
            return phrase;
        }
        public static string InfixToPrefix(string phrase, string[] operatorPriority)
        {
            string[] s = FastCode.ConvertStringToArray(phrase, operatorPriority);
            if (s.Where(x => !operatorPriority.Contains(x)).Count() - s.Where(x => operatorPriority.Contains(x) && x != "(" && x != ")").Count() != 1) throw new FormatException();

            Stack<string> operatorr = new Stack<string>(), operand = new Stack<string>();
            foreach (string i in s)
            {
                if (operatorPriority.Contains(i))
                {
                    if (i == "(" || operatorr.Count == 0 || operatorr.First() == "(") operatorr.Push(i);
                    else if (i == ")")
                    {
                        while (operatorr.First() != "(")
                        {
                            phrase = operand.Pop();
                            operand.Push(operatorr.Pop() + operand.Pop() + phrase);
                        }
                        operatorr.Pop();
                    }
                    else
                    {
                        int a = Array.IndexOf(operatorPriority, operatorr.First()), b = Array.IndexOf(operatorPriority, i);
                        if (a > b) operatorr.Push(i);
                        else if (a <= b)
                        {
                            while (operatorr.Count > 0 && Array.IndexOf(operatorPriority, operatorr.First()) <= b)
                            {
                                phrase = operand.Pop();
                                operand.Push(operatorr.Pop() + operand.Pop() + phrase);
                            }
                            operatorr.Push(i);
                        }
                        else throw new ArithmeticException();
                    }
                }
                else operand.Push(i);
            }
            while (operatorr.Count > 0)
            {
                phrase = operand.Pop();
                operand.Push(operatorr.Pop() + operand.Pop() + phrase);
            }
            return operand.First();
        }
        public static string PostfixToInfix(string phrase, string[] operatorPriority)
        {
            string[] s = phrase.Contains(',') ? FastCode.ConvertStringToArray(phrase, operatorPriority).Where(x => x != ",").ToArray() : FastCode.ConvertStringToArray(phrase, operatorPriority, true);
            if (s.Where(x => !operatorPriority.Contains(x)).Count() - s.Where(x => operatorPriority.Contains(x)).Count() != 1) throw new FormatException();

            Stack<string> operand = new Stack<string>();
            foreach (string i in s)
            {
                if (operatorPriority.Contains(i))
                {
                    phrase = operand.Pop();
                    operand.Push('(' + operand.Pop() + i + phrase + ')');
                }
                else operand.Push(i);
            }

            phrase = operand.Pop();
            return phrase.Substring(1, phrase.Length - 2);
        }
        public static string PrefixToInfix(string phrase, string[] operatorPriority)
        {
            string[] s = phrase.Contains(',') ? FastCode.ConvertStringToArray(phrase, operatorPriority).Where(x => x != ",").Reverse().ToArray() : FastCode.ConvertStringToArray(string.Concat(phrase.Reverse()), operatorPriority, true);
            if (s.Where(x => !operatorPriority.Contains(x)).Count() - s.Where(x => operatorPriority.Contains(x)).Count() != 1) throw new FormatException();

            Stack<string> operand = new Stack<string>();
            foreach (string i in s)
            {
                if (operatorPriority.Contains(i))
                {
                    operand.Push('(' + operand.Pop() + i + operand.Pop() + ')');
                }
                else operand.Push(i);
            }

            phrase = operand.Pop();
            return phrase.Substring(1, phrase.Length - 2);
        }
    }
}
