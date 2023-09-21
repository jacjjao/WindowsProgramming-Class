namespace HomeWork1
{
    class Divide : KeyWord
    {
        public const char SYMBOL = '/';
        /* 同Keyword */
        public override double Operate(double leftHandSide, double rightHandSide)
        {
            return leftHandSide / rightHandSide;
        }
    }
}
