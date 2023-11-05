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
            string a = "";
            string str = Console.ReadLine();
            str = str.Replace(" ", "");
            string operators = "+-*/";
            List<string> listNum = new List<string>();
            List<string> listOp = new List<string>();
            for (int i = 0; i < str.Length; i++)
            {
                if (operators.Contains(str[i])) listOp.Add(str[i].ToString());
            }

            for (int i = 0; i < str.Length; i++)
            {

                if (Char.IsDigit(str[i]) && (i != (str.Length - 1)))
                {
                    a += str[i].ToString();
                }
                else if (i == (str.Length - 1))
                {
                    a += str[i].ToString();
                    listNum.Add(a);
                }
                else
                {
                    listNum.Add(a);
                    a = "";
                }
            }
            var resultOp = String.Join(", ", listOp.ToArray());
            var resultNum = String.Join(", ", listNum.ToArray());
            Console.WriteLine(resultOp);
            Console.WriteLine(resultNum);
            Console.WriteLine(Calculate(listNum, listOp));
        }
        static double Calculate(List<string> listNum, List<string> listOp)
        {
            double result = Convert.ToDouble(listNum[0]);
            for (int i = 0; i < listOp.Count; i++)
            {
                if (listOp[i] == "*")
                {
                    string interimCalc = (Convert.ToDouble(listNum[i]) * Convert.ToDouble(listNum[i + 1])).ToString();
                    listNum.Insert(i, interimCalc);
                    listNum.RemoveAt(i + 1);
                    listNum.RemoveAt(i + 1);
                    //listOp.RemoveAt(i);
                }
                else if (listOp[i] == "/")
                {
                    string interimCalc = (Convert.ToDouble(listNum[i]) / Convert.ToDouble(listNum[i + 1])).ToString();
                    listNum.Insert(i, interimCalc);
                    listNum.RemoveAt(i + 1);
                    listNum.RemoveAt(i + 1);
                    //listOp.RemoveAt(i);
                }
            }
            listOp.Remove("*");
            listOp.Remove("/");
            for (int i = 0; i < listOp.Count; i++)
            {
                if (listOp[i] == "+")
                {
                    result += Convert.ToDouble(listNum[i + 1]);
                }
                else if (listOp[i] == "-")
                {
                    result -= Convert.ToDouble(listNum[i + 1]);
                }

            }
            return result;
        }
    }
}
