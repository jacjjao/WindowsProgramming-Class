﻿namespace HW1 {
    class Multiply : Keyword {
        public const char SYMBOL = 'x';
        /* 同Keyword */
        public override bool IsEqual(char c) {
            return c == SYMBOL;
        }

        /* 同Keyword */
        public override double Operate(double lhs, double rhs) {
            return lhs * rhs;
        }
    }
}
