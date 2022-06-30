namespace LiteNinja.Utils.Generics.Enumerables
{
    /// <summary>
    /// generates consecutive integers starting from a min value (inclusive)  to a max value (exclusive)
    /// </summary>
    public class CountEnumerable : IterateEnumerable<int>
    {
        public CountEnumerable(int min, int max) : base(null)
        {
            _generator = (int value) =>
            {
                if (value >= max)
                    return (value, false);
                value++;
                return (value, (value < max - 1));
            };
            _defaultValue = min - 1;
        }
    }
}