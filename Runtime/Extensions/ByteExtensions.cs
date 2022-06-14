namespace com.liteninja.utils
{
    public static class ByteExtensions
    {
        public static void SetBit0(this ref sbyte self, int bit)
        {
            self = (sbyte)(self & (~(1 << bit)));
        }

        public static void SetBit0(this ref byte self, int bit)
        {
            self = (byte)(self & (~(1u << bit)));
        }

        public static void SetBit1(this ref sbyte self, int bit)
        {
            self = (sbyte)((byte)self | (1u << bit));
        }

        public static void SetBit1(this ref byte self, int bit)
        {
            self = (byte)(self | (1u << bit));
        }

        public static void SetBit(this ref sbyte self, int bit, bool is1)
        {
            if (is1)
            {
                self.SetBit1(bit);
            }
            else
            {
                self.SetBit0(bit);
            }
        }

        public static void SetBit(this ref byte self, int bit, bool is1)
        {
            if (is1)
            {
                self.SetBit1(bit);
            }
            else
            {
                self.SetBit0(bit);
            }
        }

        public static bool GetBit(this sbyte self, int bit)
        {
            return (self & (1 << bit)) != 0;
        }

        public static bool GetBit(this byte self, int bit)
        {
            return (self & (1u << bit)) != 0;
        }

        public static void ReverseBit(this ref sbyte self, int bit)
        {
            self = (sbyte)(self ^ (1 << bit));
        }

        public static void ReverseBit(this ref byte self, int bit)
        {
            self = (byte)(self ^ (1u << bit));
        }
    }
}