using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW1
{
    class Calculator
    {
        private double last_number_ = 0;
        private char last_op_ = '\0';

        public string calculate(string math_expr)
        {
            bool input_invalid = String.IsNullOrEmpty(math_expr) || !Char.IsDigit(math_expr[math_expr.Length - 1]);
            if (input_invalid)
            {
                return null;
            }

            if (!math_expr.Any(c => (c == '+' || c == '-' || c == '*' || c == '/')))
            {
                return chainCalculate(math_expr);
            }
            string postfix_expr = toPostfixExpr(math_expr);
            return EvaluatePostfixMathExpr(postfix_expr).ToString();
        }

        private string toPostfixExpr(string math_expr)
        {
            string expr = "";
            Stack<char> stack = new Stack<char>();

            foreach (char c in math_expr)
            {
                if (isOperator(c))
                {
                    while (stack.Count > 0 && operatorPriority(stack.Peek()) >= operatorPriority(c))
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

        private string chainCalculate(string num)
        {
            double a = num.Length == 0 ? 0 : Double.Parse(num, System.Globalization.NumberStyles.Float);
            return compute(a, last_number_, last_op_).ToString();
        }

        private double EvaluatePostfixMathExpr(string postfix_expr)
        {
            double a, b;
            Stack<double> stack = new Stack<double>();
            string[] tokens = postfix_expr.Split(null);

            foreach (string token in tokens)
            {
                if (token.Length == 1 && isOperator(token[0]))
                {
                    b = last_number_ = stack.Pop();
                    a = stack.Pop();
                    stack.Push(compute(a, b, token[0]));
                    last_op_ = token[0];
                }
                else
                {
                    stack.Push(Double.Parse(token, System.Globalization.NumberStyles.Float));
                }
            }

            return stack.Peek();
        }

        private double compute(double a, double b, double op)
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

        private int operatorPriority(char c)
        {
            if (c == '*' || c == '/')
                return 2;
            else if (c == '+' || c == '-')
                return 1;
            return 0;
        }

        private bool isOperator(char c)
        {
            return c == '+' || c == '-' || c == '*' || c == '/';
        }
    }
}
