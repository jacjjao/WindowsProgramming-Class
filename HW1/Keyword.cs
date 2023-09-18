namespace HW1 {
    /* 方便以後修改/擴充 */
    public abstract class Keyword {
        /* 檢查c是不是==這個keyword的符號 */
        public abstract bool IsEqual(char c);

        /* 執行這個符號的數學操作 */
        public abstract double Operate(double lhs, double rhs);
    }
}
