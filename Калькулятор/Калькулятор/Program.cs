using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace калькулятор
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string str = Console.ReadLine();
            str = str.Replace(" ", "");
            string operators = "+-*/";
            List<char> listNum = new List<char>();
            List<char> listOp = new List<char>();
            for (int i = 0; i < str.Length; i++)
            {
                if (operators.Contains(str[i])) listOp.Add(str[i]);
                else listNum.Add(str[i]);
            }
            var resultOp = String.Join(", ", listOp.ToArray());
            var resultNum = String.Join(", ", listNum.ToArray());
            Console.WriteLine(resultOp);
            Console.WriteLine(resultNum);
            Console.WriteLine(Calculate(str));
        }
        static int Calculate(string str)
        {
            string a = str;
            int result = 0;
            for (int i = 1; i < str.Length; i++)
            {
                if ((str[i] == '*') || (str[i] == '/'))
                {
                    a = a.Replace(str[i - 1], "").Replace(str[i + 1], "");
                    if (str[i] == '*') a = a.Replace(str[i].ToString(), Convert.ToString(Convert.ToInt32(str[i - 1]) * Convert.ToInt32(str[i + 1])));
                    else a = a.Replace(str[i].ToString(), Convert.ToString(Convert.ToInt32(str[i - 1]) / Convert.ToInt32(str[i + 1])));
                }
            }
            for (int i = 1; i < a.Length; i++)
            {
                if ((a[i] == '+') || (a[i] == '-'))
                {
                    if (a[i] == '+') result += Convert.ToInt32(a[i - 1]) + Convert.ToInt32(a[i + 1]);
                    else result += Convert.ToInt32(a[i - 1]) - Convert.ToInt32(a[i + 1]);
                }
            }
            return result;
        }
    }
}