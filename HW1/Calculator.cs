using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW1
{
    class Calculator
    {
        private double _lastNumber;
        private char _lastOp;
        private readonly Dictionary<char, int> _operatorDict = new Dictionary<char, int> 
        {
            { '+', 1 },
            { '-', 1 },
            { 'x', 2 },
            { '/', 2 } 
        };

        public Calculator()
        {
            _lastOp = '\0';
            _lastNumber = 0;
        }

        /* 計算textbox上的數學式並回傳結果 */
        public string Calculate(string mathExpr)
        {
            bool inputInvalid = String.IsNullOrEmpty(mathExpr) || !Char.IsDigit(mathExpr[mathExpr.Length - 1]);
            if (inputInvalid)
            {
                return null;
            }

            if (!mathExpr.Any(c => IsOperator(c)))
            {
                return ChainCalculate(mathExpr);
            }
            string postfixExpr = ToPostfixExpr(mathExpr);
            return EvaluatePostfixMathExpr(postfixExpr).ToString();
        }

        /* 將中序數學式轉成後序 ex. (1 + 2 * 3) 轉換後會變成 (1 2 3 * +) */
        private string ToPostfixExpr(string mathExpr)
        {
            string expr = "";
            Stack<char> stack = new Stack<char>();

            foreach (char c in mathExpr)
            {
                if (IsOperator(c))
                {
                    while (stack.Count > 0 && OperatorPriority(stack.Peek()) >= OperatorPriority(c))
                    {
                        expr += ' ';
                        expr += stack.Pop();
                    }
                    expr += ' ';
                    stack.Push(c);
                }
                else
                {
                    expr += c;
                }
            }

            while (stack.Count > 0)
            {
                expr += ' ';
                expr += stack.Pop();
            }

            return expr;
        }

        /* 實現計算機可以連續計算的功能 */
        private string ChainCalculate(string num)
        {
            double a = (num.Length == 0) ? 0 : Double.Parse(num, System.Globalization.NumberStyles.Float);
            return Compute(a, _lastNumber, _lastOp).ToString();
        }

        /* 計算後序數學式並將結果傳回 */
        private double EvaluatePostfixMathExpr(string postfixExpr)
        {
            double a, b;
            Stack<double> stack = new Stack<double>();
            string[] tokens = postfixExpr.Split(null);

            foreach (string token in tokens)
            {
                if (token.Length == 1 && IsOperator(token[0]))
                {
                    b = _lastNumber = stack.Pop();
                    a = stack.Pop();
                    stack.Push(Compute(a, b, token[0]));
                    _lastOp = token[0];
                }
                else
                {
                    stack.Push(Double.Parse(token, System.Globalization.NumberStyles.Float));
                }
            }

            return stack.Peek();
        }

        /* 根據傳入的op對a b做四則運算 */
        private double Compute(double a, double b, char op)
        {
            double result = a;

            switch (op)
            {
                case '+':
                    result += b;
                    break;

                case '-':
                    result -= b;
                    break;

                case 'x':
                    result *= b;
                    break;

                case '/':
                    result /= b;
                    break;

                default:
                    break;
            }

            return result;
        } 

        /* implement中序轉後序的演算法時需要用到的function */
        private int OperatorPriority(char c)
        {
            if (IsOperator(c))
            {
                return _operatorDict[c];
            }
            return 0;
        }

        /* 檢查c是不是四則運算的符號 */
        private bool IsOperator(char c)
        {
            return _operatorDict.ContainsKey(c);
        }
    }
}
