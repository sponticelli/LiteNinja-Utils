namespace com.liteninja.utils
{
    public static class IntExtensions
    {
        /// <summary>
        /// Returns if the value is in the defined range of values, including @from and @to
        /// </summary>
        public static bool IsInRangeInclusive(this int self, int from, int to)
        {
            return self >= from && self <= to;
        }

        /// <summary>
        /// Returns if the value is in the defined range of values, excluding @from and @to
        /// </summary>
        public static bool IsInRangeExclusive(this int self, int from, int to)
        {
            return self > from && self < to;
        }

        public static int Inverse(this int self)
        {
            return self * -1;
        }
    }
}