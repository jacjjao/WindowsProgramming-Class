﻿namespace HW1
{
    class Plus : Keyword
    {
        public const char SYMBOL = '+';
        /* 同Keyword */
        public override double Operate(double lhs, double rhs)
        {
            return lhs + rhs;
        }
    }
}
