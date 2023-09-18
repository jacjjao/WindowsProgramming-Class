using System;
using System.Collections.Generic;
using System.Linq;

namespace HW1 {

    public abstract class Keyword {
        public abstract bool IsEqual(char c);
        public abstract double Operate(double a, double b);
    }

    class Plus : Keyword {
        public override bool IsEqual(char c) {
            return c == '+';
        }
        public override double Operate(double a, double b) {
            return a + b;
        }
    }

    class Subtract : Keyword {
        public override bool IsEqual(char c) {
            return c == '-';
        }
        public override double Operate(double a, double b) {
            return a - b;
        }
    }

    class Multiply : Keyword {
        public override bool IsEqual(char c) {
            return c == 'x';
        }
        public override double Operate(double a, double b) {
            return a * b;
        }
    }

    class Divide : Keyword {
        public override bool IsEqual(char c) {
            return c == '/';
        }
        public override double Operate(double a, double b) {
            return a / b;
        }
    }

    class Calculator {
        private double _lastNumber;
        private char _lastOp;
        private readonly Dictionary<Keyword, int> _operatorDict = new Dictionary<Keyword, int> {
            { new Plus(), 1 },
            { new Subtract(), 1 },
            { new Multiply(), 2 },
            { new Divide(), 2 }
        };

        public Calculator() {
            Reset();
        }

        /* 計算textbox上的數學式並回傳結果 */
        public string Calculate(string mathExpr) {
            bool inputInvalid = String.IsNullOrEmpty(mathExpr) || !Char.IsDigit(mathExpr[mathExpr.Length - 1]);
            if (inputInvalid) {
                return null;
            }

            string postfixExpr = "";
            if (mathExpr[0] == '-') {
                postfixExpr += mathExpr[0];
                mathExpr = mathExpr.Substring(1);
            }
            if (!mathExpr.Any(c => IsOperator(c))) {
                return ChainCalculate(postfixExpr + mathExpr);
            }
            postfixExpr += ToPostfixExpr(mathExpr);
            return EvaluatePostfixMathExpr(postfixExpr).ToString();
        }

        /* 將中序數學式轉成後序 ex. (1 + 2 * 3) 轉換後會變成 (1 2 3 * +) */
        private string ToPostfixExpr(string mathExpr) {
            string expr = "";
            Stack<char> stack = new Stack<char>();

            foreach (char c in mathExpr) {
                if (IsOperator(c)) {
                    while (stack.Count > 0 && OperatorPriority(stack.Peek()) >= OperatorPriority(c)) {
                        expr += ' ';
                        expr += stack.Pop();
                    }
                    expr += ' ';
                    stack.Push(c);
                }
                else {
                    expr += c;
                }
            }

            while (stack.Count > 0) {
                expr += ' ';
                expr += stack.Pop();
            }

            return expr;
        }

        /* 實現計算機可以連續計算的功能 */
        private string ChainCalculate(string num) {
            double a = (num.Length == 0) ? 0 : Double.Parse(num, System.Globalization.NumberStyles.Float);
            return Compute(a, _lastNumber, _lastOp).ToString();
        }

        /* 計算後序數學式並將結果傳回 */
        private double EvaluatePostfixMathExpr(string postfixExpr) {
            double a, b;
            Stack<double> stack = new Stack<double>();
            string[] tokens = postfixExpr.Split(null);

            foreach (string token in tokens) {
                if (token.Length == 1 && IsOperator(token[0])) {
                    b = _lastNumber = stack.Pop();
                    a = stack.Pop();
                    stack.Push(Compute(a, b, token[0]));
                    _lastOp = token[0];
                }
                else {
                    stack.Push(Double.Parse(token, System.Globalization.NumberStyles.Float));
                }
            }

            return stack.Peek();
        }
        
        /* 根據傳入的op對a b做四則運算 */
        private double Compute(double a, double b, char op) {
            foreach (var item in _operatorDict) {
                if (item.Key.IsEqual(op)) {
                    return item.Key.Operate(a, b);
                }
            }
            return 0;
        }

        /* implement中序轉後序的演算法時需要用到的function */
        private int OperatorPriority(char c) {
            foreach (var item in _operatorDict) {
                if (item.Key.IsEqual(c)) {
                    return item.Value;
                }
            }
            return 0;
        }

        /* 檢查c是不是四則運算的符號 */
        private bool IsOperator(char c) {
            foreach (var item in _operatorDict) {
                if (item.Key.IsEqual(c)) {
                    return true;
                }
            }
            return false;
        }

        public void Reset() {
            _lastOp = '+';
            _lastNumber = 0;
        }
    }
}
