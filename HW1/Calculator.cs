using System;
using System.Collections.Generic;
using System.Linq;

namespace HomeWork1
{
    class Calculator
    {
        private double _lastNumber;
        private char _lastOperation;

        private const int LOW_PRIORITY = 1;
        private const int HIGH_PRIORITY = 2;
        private readonly Dictionary<char, Tuple<KeyWord, int>> _keyWords;

        public Calculator()
        {
            _keyWords = new Dictionary<char, Tuple<KeyWord, int>>();
            _keyWords.Add(Plus.SYMBOL, new Tuple<KeyWord, int>(new Plus(), LOW_PRIORITY));
            _keyWords.Add(Subtract.SYMBOL, new Tuple<KeyWord, int>(new Subtract(), LOW_PRIORITY));
            _keyWords.Add(Multiply.SYMBOL, new Tuple<KeyWord, int>(new Multiply(), HIGH_PRIORITY));
            _keyWords.Add(Divide.SYMBOL, new Tuple<KeyWord, int>(new Divide(), HIGH_PRIORITY));
            Reset();
        }

        /* 計算textbox上的數學式並回傳結果 */
        public string Calculate(string mathExpression)
        {
            bool inputInvalid = String.IsNullOrEmpty(mathExpression) ||
                                !Char.IsDigit(mathExpression[mathExpression.Length - 1]);
            if (inputInvalid)
                return null;
            const char MINUS = '-';
            string postFixExpression = "";
            if (mathExpression[0] == MINUS)
            {
                postFixExpression += mathExpression[0];
                mathExpression = mathExpression.Substring(1);
            }
            if (!mathExpression.Any(c => IsKeyWord(c)))
                return ChainCalculate(postFixExpression + mathExpression);
            _lastOperation = mathExpression.Reverse().First(c => IsKeyWord(c));
            postFixExpression += TransformToPostFixExpression(mathExpression);
            return EvaluatePostFixMathExpression(postFixExpression).ToString();
        }

        /* 將中序數學式轉成後序 ex. (1 + 2 * 3) 轉換後會變成 (1 2 3 * +) */
        private string TransformToPostFixExpression(string mathExpression) // 沒理由把這個function切成兩個
        {
            const char SPACE = ' ';
            string postFixExpression = "";
            Stack<char> stack = new Stack<char>();
            foreach (char c in mathExpression)
            {
                if (IsKeyWord(c))
                {
                    while (stack.Count > 0 && GetKeyWordPriority(stack.Peek()) >= GetKeyWordPriority(c))
                    {
                        postFixExpression += SPACE;
                        postFixExpression += stack.Pop();
                    }
                    postFixExpression += SPACE;
                    stack.Push(c);
                }
                else
                {
                    postFixExpression += c;
                }
            }
            while (stack.Count > 0)
            {
                postFixExpression += SPACE;
                postFixExpression += stack.Pop();
            }
            return postFixExpression;
        }

        /* 實現計算機可以連續計算的功能 */
        private string ChainCalculate(string number)
        {
            double leftHandSide = (number.Length == 0) ? 0 : Double.Parse(number, System.Globalization.NumberStyles.Float);
            return Compute(leftHandSide, _lastNumber, _lastOperation).ToString();
        }

        /* 計算後序數學式並將結果傳回 */
        private double EvaluatePostFixMathExpression(string postFixExpression)
        {
            Stack<double> stack = new Stack<double>();
            string[] tokens = postFixExpression.Split(null);
            _lastNumber = Double.Parse(tokens.Reverse().First(token => !IsKeyWord(token[0])), System.Globalization.NumberStyles.Float);
            foreach (string token in tokens)
            {
                if (token.Length == 1 && IsKeyWord(token[0]))
                {
                    double rightHandSide = stack.Pop();
                    double leftHandSide = stack.Pop();
                    stack.Push(Compute(leftHandSide, rightHandSide, token[0]));
                }
                else
                {
                    stack.Push(Double.Parse(token, System.Globalization.NumberStyles.Float));
                }
            }
            return stack.Peek();
        }

        /* 根據傳入的op對a b做四則運算 */
        private double Compute(double leftHandSide, double rightHandSide, char keyWord)
        {
            var (keyword, _) = _keyWords[keyWord];
            return keyword.Operate(leftHandSide, rightHandSide);
        }

        /* implement中序轉後序的演算法時需要用到的function */
        private int GetKeyWordPriority(char character)
        {
            var (_, priority) = _keyWords[character];
            return priority;
        }

        /* 檢查c是不是四則運算的符號 */
        private bool IsKeyWord(char character)
        {
            return _keyWords.ContainsKey(character);
        }

        /* reset */
        public void Reset()
        {
            _lastOperation = Plus.SYMBOL;
            _lastNumber = 0;
        }
    }
}
