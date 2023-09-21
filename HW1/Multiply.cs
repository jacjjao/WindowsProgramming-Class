namespace HomeWork1
{
    class Multiply : KeyWord
    {
        public const char SYMBOL = 'x';
        /* 同Keyword */
        public override double Operate(double leftHandSide, double rightHandSide)
        {
            return leftHandSide * rightHandSide;
        }
    }
}
