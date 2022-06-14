namespace com.liteninja.utils
{
    public static class LongExtensions
    {
        public static void SetBit0(this ref long self, int bit)
        {
            self &= (~(1L << bit));
        }

        public static void SetBit0(this ref ulong self, int bit)
        {
            self &= (~(1UL << bit));
        }


        public static void SetBit1(this ref long self, int bit)
        {
            self |= (1L << bit);
        }

        public static void SetBit1(this ref ulong self, int bit)
        {
            self |= (1UL << bit);
        }


        public static void SetBit(this ref long self, int bit, bool is1)
        {
            if (is1) self.SetBit1(bit);
            else self.SetBit0(bit);
        }

        public static void SetBit(this ref ulong self, int bit, bool is1)
        {
            if (is1) self.SetBit1(bit);
            else self.SetBit0(bit);
        }

        public static void ReverseBit(this ref long self, int bit)
        {
            self ^= (1L << bit);
        }

        public static void ReverseBit(this ref ulong self, int bit)
        {
            self ^= (1UL << bit);
        }

        public static bool GetBit(this long self, int bit)
        {
            return (self & (1L << bit)) != 0;
        }

        public static bool GetBit(this ulong self, int bit)
        {
            return (self & (1UL << bit)) != 0;
        }
    }
}