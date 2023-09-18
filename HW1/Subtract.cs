namespace HW1 {
    class Subtract : Keyword {
        public static readonly char _symbol = '-';
        /* 同Keyword */
        public override bool IsEqual(char c) {
            return c == _symbol;
        }

        /* 同Keyword */
        public override double Operate(double lhs, double rhs) {
            return lhs - rhs;
        }
    }
}
