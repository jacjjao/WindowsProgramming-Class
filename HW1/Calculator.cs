using System;
using System.Collections.Generic;
using System.Linq;

namespace HW1
{
    class Calculator
    {
        private double _lastNumber;
        private char _lastOp;

        private const int LOW_PRIORITY = 1;
        private const int HIGH_PRIORITY = 2;
        private readonly Dictionary<char, Tuple<Keyword, int>> _keywords = new Dictionary<char, Tuple<Keyword, int>>
        {
            { Plus.SYMBOL, new Tuple<Keyword, int>(new Plus(), LOW_PRIORITY) },
            { Subtract.SYMBOL, new Tuple<Keyword, int>(new Subtract(), LOW_PRIORITY) },
            { Multiply.SYMBOL, new Tuple<Keyword, int>(new Multiply(), HIGH_PRIORITY) },
            { Divide.SYMBOL, new Tuple<Keyword, int>(new Divide(), HIGH_PRIORITY) },
        };

        public Calculator()
        {
            Reset();
        }

        /* 計算textbox上的數學式並回傳結果 */
        public string Calculate(string mathExpr)
        {
            bool inputInvalid = String.IsNullOrEmpty(mathExpr) ||
                                !Char.IsDigit(mathExpr[mathExpr.Length - 1]);
            if (inputInvalid)
            {
                return null;
            }

            const char MINUS = '-';
            string postfixExpr = "";
            if (mathExpr[0] == MINUS)
            {
                postfixExpr += mathExpr[0];
                mathExpr = mathExpr.Substring(1);
            }
            if (!mathExpr.Any(c => IsKeyword(c)))
            {
                return ChainCalculate(postfixExpr + mathExpr);
            }
            _lastOp = mathExpr.Reverse().First(c => IsKeyword(c));
            postfixExpr += TransformToPostfixExpr(mathExpr);
            return EvaluatePostfixMathExpr(postfixExpr).ToString();
        }

        /* 將中序數學式轉成後序 ex. (1 + 2 * 3) 轉換後會變成 (1 2 3 * +) */
        private string TransformToPostfixExpr(string mathExpr)
        {
            const char SPACE = ' ';
            string expr = "";
            Stack<char> stack = new Stack<char>();

            foreach (char c in mathExpr)
            {
                if (IsKeyword(c))
                {
                    while (stack.Count > 0 && GetKeywordPriority(stack.Peek()) >= GetKeywordPriority(c))
                    {
                        expr += SPACE;
                        expr += stack.Pop();
                    }
                    expr += SPACE;
                    stack.Push(c);
                }
                else
                {
                    expr += c;
                }
            }
            while (stack.Count > 0)
            {
                expr += SPACE;
                expr += stack.Pop();
            }

            return expr;
        }

        /* 實現計算機可以連續計算的功能 */
        private string ChainCalculate(string num)
        {
            double lhs = (num.Length == 0) ? 0 : Double.Parse(num, System.Globalization.NumberStyles.Float);
            return Compute(lhs, _lastNumber, _lastOp).ToString();
        }

        /* 計算後序數學式並將結果傳回 */
        private double EvaluatePostfixMathExpr(string postfixExpr)
        {
            double lhs;
            double rhs;
            Stack<double> stack = new Stack<double>();
            string[] tokens = postfixExpr.Split(null);
            _lastNumber = Double.Parse(tokens.Reverse().First(token => !IsKeyword(token[0])), System.Globalization.NumberStyles.Float);

            foreach (string token in tokens)
            {
                if (token.Length == 1 && IsKeyword(token[0]))
                {
                    rhs = stack.Pop();
                    lhs = stack.Pop();
                    stack.Push(Compute(lhs, rhs, token[0]));
                }
                else
                {
                    stack.Push(Double.Parse(token, System.Globalization.NumberStyles.Float));
                }
            }

            return stack.Peek();
        }

        /* 根據傳入的op對a b做四則運算 */
        private double Compute(double lhs, double rhs, char op)
        {
            var (keyword, _) = _keywords[op];
            return keyword.Operate(lhs, rhs);
        }

        /* implement中序轉後序的演算法時需要用到的function */
        private int GetKeywordPriority(char c)
        {
            var (_, priority) = _keywords[c];
            return priority;
        }

        /* 檢查c是不是四則運算的符號 */
        private bool IsKeyword(char c)
        {
            return _keywords.ContainsKey(c);
        }

        /* reset */
        public void Reset()
        {
            _lastOp = Plus.SYMBOL;
            _lastNumber = 0;
        }
    }
}
