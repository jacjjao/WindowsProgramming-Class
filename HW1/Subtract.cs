namespace HW1
{
    class Subtract : Keyword
    {
        public const char SYMBOL = '-';
        /* 同Keyword */
        public override bool IsEqual(char word)
        {
            return word == SYMBOL;
        }

        /* 同Keyword */
        public override double Operate(double lhs, double rhs)
        {
            return lhs - rhs;
        }
    }
}
