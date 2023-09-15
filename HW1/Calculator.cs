using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW1
{
    class Calculator
    {
        private double _last_number = 0;
        private char _last_op = '\0';

        public string Calculate(string mathExpr)
        {
            bool inputInvalid = String.IsNullOrEmpty(mathExpr) || !Char.IsDigit(mathExpr[mathExpr.Length - 1]);
            if (inputInvalid)
            {
                return null;
            }

            if (!mathExpr.Any(c => (c == '+' || c == '-' || c == '*' || c == '/')))
            {
                return ChainCalculate(mathExpr);
            }
            string postfixExpr = ToPostfixExpr(mathExpr);
            return EvaluatePostfixMathExpr(postfixExpr).ToString();
        }

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

        private string ChainCalculate(string num)
        {
            double a = num.Length == 0 ? 0 : Double.Parse(num, System.Globalization.NumberStyles.Float);
            return Compute(a, _last_number, _last_op).ToString();
        }

        private double EvaluatePostfixMathExpr(string postfixExpr)
        {
            double a, b;
            Stack<double> stack = new Stack<double>();
            string[] tokens = postfixExpr.Split(null);

            foreach (string token in tokens)
            {
                if (token.Length == 1 && IsOperator(token[0]))
                {
                    b = _last_number = stack.Pop();
                    a = stack.Pop();
                    stack.Push(Compute(a, b, token[0]));
                    _last_op = token[0];
                }
                else
                {
                    stack.Push(Double.Parse(token, System.Globalization.NumberStyles.Float));
                }
            }

            return stack.Peek();
        }

        private double Compute(double a, double b, double op)
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

                case '*':
                    result *= b;
                    break;

                case '/':
                    result /= b;
                    break;
            }

            return result;
        }

        private int OperatorPriority(char c)
        {
            if (c == '*' || c == '/')
                return 2;
            else if (c == '+' || c == '-')
                return 1;
            return 0;
        }

        private bool IsOperator(char c)
        {
            return c == '+' || c == '-' || c == '*' || c == '/';
        }
    }
}
