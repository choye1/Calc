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
            string userStr = Console.ReadLine();
            userStr = userStr.Replace(" ", "");
            string operators = "+-*/^()";
            List<string> listNum = new List<string>();
            List<string> listOp = new List<string>();
            List<object> tokens = new List<object>();
          

            for (int i = 0; i < userStr.Length; i++)
            {
                if (operators.Contains(userStr[i]))
                {
                    listOp.Add(userStr[i].ToString());    
                }
                if (Char.IsDigit(userStr[i]) && (i != (userStr.Length - 1)))
                {
                    a += userStr[i].ToString();
                }
                else if (i == (userStr.Length - 1))
                {
                    a += userStr[i].ToString();
                    listNum.Add(a);
                    tokens.Add(a);
                }
                else
                {
                    listNum.Add(a);
                    tokens.Add(a);
                    tokens.Add(userStr[i].ToString());
                    a = "";
                    listNum.Remove("");
                    tokens.Remove("");
                }
            }
            var resultOp = String.Join(", ", listOp.ToArray());
            var resultNum = String.Join(", ", listNum.ToArray());
            var resultTokens = String.Join(", ", tokens.ToArray());
            Console.WriteLine(resultOp);
            Console.WriteLine(resultNum);
            Console.WriteLine(resultTokens);
            RPNImport(tokens);
            
            //Console.WriteLine(Calculate(listNum, listOp));
            Console.ReadLine();
        }
        static List<object> RPNImport(List<object> tokens)
        {
            Dictionary<string, int> OperationPriority = new Dictionary<string, int>()
            {
                {"+", 2 },
                {"-", 2 },
                {"*", 3 },
                {"/", 3 },
                {"^", 4 },
                {"(", 0 },
                {")", 1 }
            };
            List<object> RPN = new List<object>();
            Stack<object> stackForOp = new Stack<object>();
            for (int i = 0; i < tokens.Count; i++)
            {
                if (float.TryParse(tokens[i].ToString(), out float n) == true)
                {
                    RPN.Add(tokens[i]);
                }
                else if (float.TryParse(tokens[i].ToString(),out float n1) == false)
                {
                    if (stackForOp.Count == 0)
                    {
                        stackForOp.Push(tokens[i]);
                    }
                    else if (OperationPriority[tokens[i].ToString()] > OperationPriority[stackForOp.Peek().ToString()])
                    {
                        stackForOp.Push(tokens[i]);
                    }
                    else if(OperationPriority[tokens[i].ToString()] == 1)
                    {
                        while (OperationPriority[stackForOp.Peek().ToString()] > 0)
                        {
                            RPN.Add(stackForOp.Pop());
                        }
                        stackForOp.Pop();
                    }
                    else if (OperationPriority[tokens[i].ToString()] <= OperationPriority[stackForOp.Peek().ToString()])
                    {
                        RPN.Add(stackForOp.Pop());
                        stackForOp.Push(tokens[i]);
                    }
                }
            }
            if (stackForOp.Count > 0)
            {
                while (stackForOp.Count != 0)
                {
                    RPN.Add(stackForOp.Pop());
                }
            }
            var resultRpn = String.Join(", ", RPN.ToArray());
            Console.WriteLine(resultRpn);
            return RPN;
            
        }

        //static double Calculate(List<string> listNum, List<string> listOp)
        //{
        //    double result = Convert.ToDouble(listNum[0]);
        //    for (int i = 0; i < listOp.Count; i++)
        //    {
        //        if (listOp[i] == "*")
        //        {
        //            string interimCalc = (Convert.ToDouble(listNum[i]) * Convert.ToDouble(listNum[i + 1])).ToString();
        //            i = DeleteNumOp(listNum, listOp, i, interimCalc);
        //        }
        //        else if (listOp[i] == "/")
        //        {
        //            string interimCalc = (Convert.ToDouble(listNum[i]) / Convert.ToDouble(listNum[i + 1])).ToString();
        //            i = DeleteNumOp(listNum, listOp, i, interimCalc);
        //        }
        //    }
        //    if (listOp.Count == 0) return Convert.ToDouble(listNum[0]);
        //    else
        //    {
        //        for (int i = 0; i < listOp.Count; i++)
        //        {
        //            if (listOp[i] == "+")
        //            {
        //                result += Convert.ToDouble(listNum[i + 1]);
        //            }
        //            else if (listOp[i] == "-")
        //            {
        //                result -= Convert.ToDouble(listNum[i + 1]);
        //            }
        //        }
        //        return result;
        //    }
        //}

        //private static int DeleteNumOp(List<string> listNum, List<string> listOp, int i, string interimCalc)
        //{
        //    listNum.Insert(i, interimCalc);
        //    listNum.RemoveAt(i + 1);
        //    listNum.RemoveAt(i + 1);
        //    listOp.RemoveAt(i);
        //    i--;
        //    return i;
        //}
    }
}