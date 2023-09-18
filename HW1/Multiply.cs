namespace HW1 {
    class Multiply : Keyword {
        public static readonly char _symbol = 'x';
        /* 同Keyword */
        public override bool IsEqual(char c) {
            return c == _symbol;
        }

        /* 同Keyword */
        public override double Operate(double lhs, double rhs) {
            return lhs * rhs;
        }
    }
}
