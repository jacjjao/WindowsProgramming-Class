﻿namespace HW1
{
    class Divide : Keyword
    {
        public const char SYMBOL = '/';
        /* 同Keyword */
        public override double Operate(double lhs, double rhs)
        {
            return lhs / rhs;
        }
    }
}
